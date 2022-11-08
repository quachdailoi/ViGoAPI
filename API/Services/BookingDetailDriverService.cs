using API.Extensions;
using API.Models;
using API.Models.DTO;
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
            var detailDrivers = UnitOfWork.BookingDetailDrivers.List(x => codes.Contains(x.Code.ToString()));

            var updatedDetailDrivers = detailDrivers.ToList().Select(x => { x.TripStatus = BookingDetailDrivers.TripStatus.Start; return x; }).ToArray();

            return UnitOfWork.BookingDetailDrivers.UpdateRange(updatedDetailDrivers);
        }

        public async Task<bool?> CancelBookingDetailDrivers(string[] codes, string reason)
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

            if(updatedDetailDrivers.Any(x => x.BookingDetail.Date <= DateTimeExtensions.NowDateOnly) || updatedDetailDrivers.Count() != codes.Count())
                return null;

            if (!UnitOfWork.BookingDetailDrivers.UpdateRange(updatedDetailDrivers).Result)
                return false;

            foreach (var updatedDetailDriver in updatedDetailDrivers)
            {
                await AppServices.RedisMQ.Publish(MappingBookingTask.MAPPING_QUEUE, new MappingItemDTO { Id = updatedDetailDriver.BookingDetailId, Type = TaskItems.MappingItemTypes.BookingDetail });
            }

            return true;
        }

        public async Task<bool> UpdateTripStatus(BookingDetailDriver bookingDetailDriver, BookingDetailDrivers.TripStatus tripStatus)
        {
            bookingDetailDriver.TripStatus = tripStatus;

            var bookingDetail = await AppServices.BookingDetail.GetById(bookingDetailDriver.BookingDetailId);

            if (bookingDetail == null) throw new Exception("Something went wrong, not found booking detail of this driver.");

            var today = DateTimeExtensions.NowDateOnly;
            var bookingDetailDate = bookingDetail.Date;

            var now = DateTimeExtensions.NowTimeOnly;
            var bookingDetailTime = bookingDetail.Booking.Time;

            if (tripStatus == BookingDetailDrivers.TripStatus.PickedUp || tripStatus == BookingDetailDrivers.TripStatus.Completed)
                if (today < bookingDetailDate || now < bookingDetailTime) throw new Exception("This booking detail of driver doesn't occur today so cannot set status PickedUp and Completed for it.");

            if (bookingDetail != null)
            {
                switch (tripStatus)
                {
                    case BookingDetailDrivers.TripStatus.PickedUp:
                        bookingDetail.Status = BookingDetails.Status.Started;
                        bookingDetailDriver.BookingDetail = bookingDetail;
                        bookingDetailDriver.StartTime = TimeOnly.FromDateTime(DateTimeOffset.Now.DateTime);
                        break;
                    case BookingDetailDrivers.TripStatus.Completed:
                        bookingDetail.Status = BookingDetails.Status.Completed;
                        bookingDetailDriver.BookingDetail = bookingDetail;
                        bookingDetailDriver.EndTime = TimeOnly.FromDateTime(DateTimeOffset.Now.DateTime);

                        var wallet = await AppServices.Wallet.GetWallet(bookingDetailDriver.RouteRoutine.UserId);

                        if (wallet != null)
                        {
                            var tradeDiscount = double.Parse(AppServices.Setting.GetValue(Settings.TradeDiscount).Result ?? "0.2");

                            var transactionDto = new WalletTransactionDTO
                            {
                                Amount = Fee.FloorToHundreds((bookingDetail.Price + bookingDetail.DiscountPrice) * (1-tradeDiscount)),
                                Status = WalletTransactions.Status.Success,
                                WalletId = wallet.Id,
                                Type = WalletTransactions.Types.TripIncome
                            };

                            if ((wallet = AppServices.Wallet.UpdateBalance(transactionDto).Result) != null)
                                await AppServices.SignalR.SendToUserAsync(bookingDetailDriver.RouteRoutine.User.Code.ToString(), "WalletTransaction", new WalletTransactionViewModel
                                {
                                    Amount = transactionDto.Amount,
                                    Code = transactionDto.Code,
                                    Status = transactionDto.Status,
                                    Type = transactionDto.Type,
                                    Time = wallet.WalletTransactions.Last().UpdatedAt.ToFormatString()
                                });

                        }
                        break;
                }

                // cancelled

                await AppServices.SignalR.SendToUserAsync(bookingDetail.Booking.User.Code.ToString(), "TripStatus", new
                {
                    BookingDetailDriverCode = bookingDetailDriver.Code,
                    TripStatus = tripStatus,
                    TripStatusName = tripStatus.DisplayName()
                });
            }
            else Logger<BookingDetailDriverService>().LogError("Error: Booking detail null -> cannot set complete or send signal");

            return await UnitOfWork.BookingDetailDrivers.Update(bookingDetailDriver);
        }

        public List<User> GetUsers(string[] codes)
        {
            var users = UnitOfWork.BookingDetailDrivers.List(x => codes.Contains(x.Code.ToString())).Select(x => x.BookingDetail.Booking.User).ToList();

            return users;
        }
    }
}
