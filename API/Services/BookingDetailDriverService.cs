using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using API.TaskQueues.TaskResolver;
using API.Utils;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using Twilio.Rest.Api.V2010.Account;

namespace API.Services
{
    public class BookingDetailDriverService : BaseService, IBookingDetailDriverService
    {
        public BookingDetailDriverService(IAppServices appServices) : base(appServices)
        {
        }

        public Task<List<BookingDetailDriver>> Create(List<BookingDetailDriver> bookingDetailDrivers) => UnitOfWork.BookingDetailDrivers.Add(bookingDetailDrivers);

        public async Task<BookingDetailDriver?> GetBookingDetailDriverByCode(string code)
        {
            return await UnitOfWork.BookingDetailDrivers
                .List(x => x.Code.ToString() == code)
                .Include(x => x.RouteRoutine)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync();
        }

        public Task<bool> StartBookingDetailDrivers(string[] codes)
        {
            var detailDrivers = UnitOfWork.BookingDetailDrivers.List(x => codes.Contains(x.Code.ToString())).Include(x => x.BookingDetail);

            var updatedDetailDrivers = detailDrivers.ToList().Select(x => {
                    x.TripStatus = BookingDetailDrivers.TripStatus.Start;
                    x.BookingDetail.Status = BookingDetails.Status.Started;
                    return x;
            }).ToArray();

            return UnitOfWork.BookingDetailDrivers.UpdateRange(updatedDetailDrivers);
        }

        public async Task<Response> CancelBookingDetailDrivers(string[] codes, string reason, Response invalidAllowedTimeResponse, 
            Response invalidBookingDetailDriverResponse, Response successResponse, Response failResponse)
        {
            var detailDrivers = UnitOfWork.BookingDetailDrivers.List(x => codes.Contains(x.Code.ToString()));

            var updatedDetailDrivers = detailDrivers
                .Include(x => x.BookingDetail)
                .ToList()
                .Select(x => 
                { 
                    x.TripStatus = BookingDetailDrivers.TripStatus.Cancelled; 
                    x.BookingDetail.Status = BookingDetails.Status.Pending;
                    x.BookingDetail.MessageRoom = null;
                    x.BookingDetail.MessageRoomId = null;
                    x.CancelledReason = reason;
                    return x; 
                })
                .ToArray();

            //if (updatedDetailDrivers.Any(bdr => bdr.BookingDetail.Date == DateTimeExtensions.NowDateOnly.AddDays(1)))
            //{
            //    //var allowedDriverCancelTripTimeStr = await AppServices.Setting.GetValue(Settings.AllowedDriverCancelTripTime);

            //    //var allowedDriverCancelTripTime = allowedDriverCancelTripTimeStr != null ? TimeOnly.Parse(allowedDriverCancelTripTimeStr) : new TimeOnly(19, 45);

            //    var allowedDriverCancelTripTime = new TimeOnly(19, 45);

            //    if (DateTimeExtensions.NowTimeOnly > allowedDriverCancelTripTime)
            //        return invalidAllowedTimeResponse;
            //}

            if (updatedDetailDrivers.Any(x => x.BookingDetail.Date <= DateTimeExtensions.NowDateOnly) || updatedDetailDrivers.Count() != codes.Count())
                return invalidBookingDetailDriverResponse;

            if (!UnitOfWork.BookingDetailDrivers.UpdateRange(updatedDetailDrivers).Result)
                return failResponse;

            foreach (var updatedDetailDriver in updatedDetailDrivers)
            {
                await AppServices.RedisMQ.Publish(MappingBookingTask.MAPPING_QUEUE, new MappingItemDTO { Id = updatedDetailDriver.BookingDetailId, Type = TaskItems.MappingItemTypes.BookingDetail });
            }
           
            return successResponse;
        }

        public async Task<bool> UpdateTripStatus(BookingDetailDriver bookingDetailDriver, BookingDetailDrivers.TripStatus tripStatus, double? latitude, double? longitude)
        {
            var bookingDetail = await AppServices.BookingDetail.GetById(bookingDetailDriver.BookingDetailId);

            if (bookingDetail == null) throw new Exception("Something went wrong, not found booking detail of this driver.");
            
            if (bookingDetail != null)
            {
                var today = DateTimeExtensions.NowDateOnly;
                var bookingDetailDate = bookingDetail.Date;

                var now = DateTimeExtensions.NowTimeOnly;
                var bookingDetailTime = bookingDetail.Booking.Time;

                switch (tripStatus)
                {
                    case BookingDetailDrivers.TripStatus.PickedUp:
                        //if (today < bookingDetailDate || now < bookingDetailTime.AddMinutes(-1 * await AppServices.Setting.GetValue(Settings.TimeBeforePickingUp, 10))) 
                        //    throw new Exception("Invalid time to set status PickedUp for it.");

                        //await CheckRadiusFromStartStation(bookingDetail, latitude, longitude);

                        bookingDetail.Status = BookingDetails.Status.Started;
                        bookingDetailDriver.BookingDetail = bookingDetail;
                        bookingDetailDriver.StartTime = TimeOnly.FromDateTime(DateTimeOffset.Now.DateTime);
                        break;
                    case BookingDetailDrivers.TripStatus.Completed:
                        //if (today < bookingDetailDate || now < bookingDetailTime.AddMinutes(await AppServices.Setting.GetValue(Settings.TimeAfterComplete, 3))) 
                        //    throw new Exception("Invalid time to set status Completed for it.");

                        if (bookingDetailDriver.TripStatus == BookingDetailDrivers.TripStatus.Start)
                        {
                            //await CheckRadiusFromStartStation(bookingDetail, latitude, longitude);
                        } 
                        else
                        {
                            //await CheckRadiusFromEndStation(bookingDetail, latitude, longitude);
                        }

                        bookingDetail.Status = BookingDetails.Status.Completed;
                        bookingDetailDriver.BookingDetail = bookingDetail;
                        bookingDetailDriver.EndTime = TimeOnly.FromDateTime(DateTimeOffset.Now.DateTime);
                        break;
                }

                // cancelled

                await AppServices.SignalR.SendToUserAsync(bookingDetail.Booking.User.Code.ToString(), "TripStatus", new
                {
                    BookingDetailDriverCode = bookingDetailDriver.Code,
                    BookingDetailCode = bookingDetailDriver.BookingDetail.Code,
                    TripStatus = tripStatus,
                    TripStatusName = tripStatus.DisplayName()
                });
            }
            else Logger<BookingDetailDriverService>().LogError("Error: Booking detail null -> cannot set complete or send signal");

            bookingDetailDriver.TripStatus = tripStatus;

            if(await UnitOfWork.BookingDetailDrivers.Update(bookingDetailDriver))
            {
                switch (bookingDetailDriver.TripStatus)
                {
                    case BookingDetailDrivers.TripStatus.Completed:
                        var wallet = await AppServices.Wallet.GetWallet(bookingDetailDriver.RouteRoutine.UserId);

                        var totalFee = bookingDetail.Price + bookingDetail.DiscountPrice;

                        if (bookingDetail.Booking.IsShared)
                        {
                            var bookerReturnFee = (await AppServices.BookingDetail.CaculateFeeAfterCompleted(bookingDetail.Code))?.DiscountFee;

                            if (bookerReturnFee.HasValue && bookerReturnFee.Value > 0)
                            {
                                await AppServices.RedisMQ.Publish(RefundBookingTask.REFUND_QUEUE, new RefundItemDTO
                                {
                                    Amount = bookerReturnFee.Value,
                                    Code = bookingDetail.Code,
                                    Type = TaskItems.RefundItemTypes.TripSharing
                                });

                                totalFee -= bookerReturnFee.Value;
                            }
                        }

                        if (wallet != null)
                        {
                            var tradeDiscount = await AppServices.Setting.GetValue<double>(Settings.TradeDiscount, 0.2);

                            var transactionDto = new WalletTransactionDTO
                            {
                                Amount = Fee.FloorToHundreds(totalFee * (1 - tradeDiscount)),
                                Status = WalletTransactions.Status.Success,
                                WalletId = wallet.Id,
                                Type = WalletTransactions.Types.TripIncome,
                                BookingId = bookingDetail.Booking.Id
                            };

                            if ((wallet = AppServices.Wallet.UpdateBalance(transactionDto).Result) != null)
                            {
                                var notiDTO = new NotificationDTO()
                                {
                                    EventId = Events.Types.TripIncome,
                                    Type = Notifications.Types.SpecificUser,
                                    Token = bookingDetailDriver.RouteRoutine.User.FCMToken,
                                    UserId = bookingDetailDriver.RouteRoutine.UserId
                                };

                                await AppServices.Notification.SendPushNotification(notiDTO);
                            }
                        }
                        break;
                }
                return true;
            };

            return false;
        }

        private async Task CheckRadiusFromEndStation(BookingDetail detail, double? latitude, double? longitude)
        {
            var booking = UnitOfWork.BookingDetails.List(x => x.Id == detail.Id).Select(x => x.Booking);

            var endStation = booking.Select(x => x.EndRouteStation.Station).FirstOrDefault();

            if (latitude == null || longitude == null || endStation == null)
                throw new Exception("Must input coordinate for checking location.");

            var endStationLatitude = endStation.Latitude;
            var endStationLongitude = endStation.Longitude;

            var distance = ILocationService.CalculateDistanceAsTheCrowFlies(endStationLatitude, endStationLongitude, (double)latitude, (double)longitude);
            var radius = await AppServices.Setting.GetValue(Settings.RadiusToComplete, 100.0);

            if (distance > radius)
                throw new Exception($"Your location must be within {radius}m from the end station.");
        }

        private async Task CheckRadiusFromStartStation(BookingDetail detail, double? latitude, double? longitude)
        {
            var booking = UnitOfWork.BookingDetails.List(x => x.Id == detail.Id).Select(x => x.Booking);

            var startStation = booking.Select(x => x.StartRouteStation.Station).FirstOrDefault();

            if (latitude == null || longitude == null || startStation == null)
                throw new Exception("Must input coordinate for checking location.");

            var startStationLatitude = startStation.Latitude;
            var startStationLongitude = startStation.Longitude;

            var distance = ILocationService.CalculateDistanceAsTheCrowFlies(startStationLatitude, startStationLongitude, (double)latitude, (double)longitude);
            var radius = await AppServices.Setting.GetValue(Settings.RadiusToComplete, 100.0);

            if (distance > radius)
                throw new Exception($"Your location must be within {radius}m from the start station.");
        }

        public List<User> GetUsers(string[] codes)
        {
            var users = UnitOfWork.BookingDetailDrivers.List(x => codes.Contains(x.Code.ToString())).Select(x => x.BookingDetail.Booking.User).ToList();

            return users;
        }
    }
}
