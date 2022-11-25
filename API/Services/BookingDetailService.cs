using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using API.Services.Constract;
using API.TaskQueues.TaskResolver;
using API.Utils;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Services
{
    public class BookingDetailService : BaseService, IBookingDetailService
    {

        public BookingDetailService(IAppServices appServices) : base(appServices)
        {
        }

        public List<BookingDetail> GenerateBookingDetail(Booking booking, FeeViewModel feePerTrip)
        {
            List<BookingDetail> bookingDetails = new();
            for (var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
            {
                if(booking.DayOfWeeks.Contains(day.DayOfWeek))
                    bookingDetails.Add(new BookingDetail
                    {
                        Booking = booking,
                        Date = day,
                        Price = feePerTrip.TotalFee,
                        DiscountPrice = feePerTrip.DiscountFee
                    });
            }
            return bookingDetails;
        }

        public async Task<Response> GetNextBookingDetail(int userId, Response successResponse)
        {
            var bookingDetailsIQueryable = UnitOfWork.BookingDetails.List(b => b.Booking.UserId == userId && b.Status != BookingDetails.Status.Completed)
                                                                .OrderBy(b => b.Date)
                                                                .ThenBy(b => b.Booking.Time);


            var bookingDetail = await bookingDetailsIQueryable.MapTo<BookerBookingDetailViewModel>(Mapper, AppServices).FirstOrDefaultAsync();

            return successResponse.SetData(bookingDetail);
        }

        public async Task<Response> GetBookingsOfDriver(int driverId, PagingRequest request, DateFilterRequest dateFilter, Response success)
        {
            var bookingDetails = UnitOfWork.BookingDetails.GetBookingDetailsByDriverId(driverId).Where(x => x.Status != BookingDetails.Status.Cancelled && x.Status != BookingDetails.Status.Completed);

            if (dateFilter.FromDate != null && dateFilter.ToDate != null)
            {
                var fromDateParse = DateTimeExtensions.ParseExactDateOnly(dateFilter.FromDate);
                var toDateParse = DateTimeExtensions.ParseExactDateOnly(dateFilter.ToDate);

                bookingDetails = bookingDetails.Where(x => x.Date >= fromDateParse && x.Date <= toDateParse);
            }

            bookingDetails = bookingDetails.OrderByDescending(x => x.Date);

            List<DriverScheduleViewModel> driverSchedules = new();

            var scheduleDates = bookingDetails.Select(x => x.Date).Distinct().OrderBy(x => x);

            var paging = scheduleDates.Paging(page: request.Page, pageSize: request.PageSize);

            scheduleDates = paging.Items.OrderBy(x => x);

            if (scheduleDates == null)
            {
                return success;
            }

            foreach (var date in scheduleDates)
            {
                driverSchedules.Add(new DriverScheduleViewModel
                {
                    Date = date
                });
            }

            foreach (var driverSchedule in driverSchedules)
            {
                var detailRoutines = new List<BookingDetailRoutineDTO>();

                UnitOfWork.RouteRoutines.GetAllRouteRoutine(driverId).Include(x => x.Route).OrderBy(x => x.StartTime).ToList()
                    .Where(routine =>
                    {
                        var details = bookingDetails.Where(x => x.Date == driverSchedule.Date).OrderBy(x => x.Booking.Time)
                            .Where(bd => bd.BookingDetailDrivers.Where(x => x.TripStatus != BookingDetailDrivers.TripStatus.Cancelled).FirstOrDefault().RouteRoutine.Id == routine.Id);

                        if (details.Any())
                            detailRoutines.Add(new()
                            {
                                Routine = routine,
                                BookingDetails = details
                            });

                        return details.Any();
                    }).ToList();

                foreach (var routineDetail in detailRoutines)
                {
                    var routine = routineDetail.Routine;

                    RouteScheduleViewModel routeSchedule = new()
                    {
                        RouteCode = routine.Route.Code.ToString(),
                        StartTime = routine.StartTime
                    };

                    var detailsInRouteRoutine = routineDetail.BookingDetails
                        .Where(x => x.Booking.StartRouteStation.RouteId == routine.RouteId)
                        .Where(x => x.Status != BookingDetails.Status.Cancelled && x.Status != BookingDetails.Status.Completed); 

                    if (!detailsInRouteRoutine.Any()) continue;

                    var schedules = detailsInRouteRoutine.Select(x => new ScheduleBookingDetailViewModel
                    {
                        BookingDetailDriverCode = x.BookingDetailDrivers.Where(bdd => bdd.RouteRoutine.UserId == driverId)
                            .Where(bdd => bdd.TripStatus != BookingDetailDrivers.TripStatus.Cancelled && bdd.TripStatus != BookingDetailDrivers.TripStatus.Completed)
                            .OrderByDescending(x => x.CreatedAt)
                            .Select(x => x.Code).FirstOrDefault(),
                        TripStatus = x.BookingDetailDrivers.Where(bdd => bdd.RouteRoutine.UserId == driverId)
                            .Where(bdd => bdd.TripStatus != BookingDetailDrivers.TripStatus.Cancelled && bdd.TripStatus != BookingDetailDrivers.TripStatus.Completed)
                            .OrderByDescending(x => x.CreatedAt)
                            .Select(x => x.TripStatus).FirstOrDefault(),
                        Time = x.Booking.Time,
                        StartStation = new()
                        {
                            Code = x.Booking.StartRouteStation.Station.Code,
                            Name = x.Booking.StartRouteStation.Station.Name,
                            Address = x.Booking.StartRouteStation.Station.Address,
                            Index = x.Booking.StartRouteStation.Index,
                            Longitude = x.Booking.StartRouteStation.Station.Longitude,
                            Latitude = x.Booking.StartRouteStation.Station.Latitude
                        },
                        EndStation = new()
                        {
                            Code = x.Booking.EndRouteStation.Station.Code,
                            Name = x.Booking.EndRouteStation.Station.Name,
                            Address = x.Booking.EndRouteStation.Station.Address,
                            Index = x.Booking.EndRouteStation.Index,
                            Longitude = x.Booking.EndRouteStation.Station.Longitude,
                            Latitude = x.Booking.EndRouteStation.Station.Latitude
                        },
                        Distance = CalculateDistanceFromStartToEndStation(x.Booking.StartRouteStation.Route.RouteStations, x.Booking.StartRouteStation.StationId, x.Booking.EndRouteStation.StationId, x.Booking.StartRouteStation.Route.Distance),
                        User = new()
                        {

                            Code = x.Booking.User.Code,
                            Name = x.Booking.User.Name,
                            Gender = x.Booking.User.Gender,
                            PhoneNumber = GetUserPhoneNumber(x.Booking.User.Accounts),
                            ChattingRoomCode = GetMessageRoomCode(x.MessageRoom),
                            PaymentMethod = x.Booking.PaymentMethod,
                            PaymentStatus = x.Booking.Status
                        }
                    }).ToList();

                    // add schedules
                    routeSchedule.Schedules = schedules;

                    var startStepInSchedules = schedules.Select(x => new StepScheduleViewModel()
                    {
                        BookingDetailDriverCode = x.BookingDetailDriverCode,
                        StationCode = x.StartStation.Code,
                        StationName = x.StartStation.Name,
                        TripStatus = x.TripStatus,
                        UserName = x.User.Name,
                        Type = BookingDetailDrivers.StepScheduleType.PickUp,
                        Index = x.StartStation.Index,
                        Time = x.Time,
                        Longitude = x.StartStation.Longitude,
                        Latitude = x.StartStation.Latitude
                    });

                    var endStepInSchedules = schedules.Select(x => new StepScheduleViewModel()
                    {
                        BookingDetailDriverCode = x.BookingDetailDriverCode,
                        StationCode = x.EndStation.Code,
                        StationName = x.EndStation.Name,
                        TripStatus = x.TripStatus,
                        UserName = x.User.Name,
                        Type = BookingDetailDrivers.StepScheduleType.DropOff,
                        Index = x.EndStation.Index,
                        Time = x.Time,
                        Longitude = x.EndStation.Longitude,
                        Latitude = x.EndStation.Latitude
                    });

                    var stepInSchedules = startStepInSchedules.Concat(endStepInSchedules).OrderBy(x => x.Time).ThenBy(x => x.Index)
                        .Where(ValidTripStatus).ToList();

                    routeSchedule.Steps = ConvertTo<StepScheduleViewModel>(stepInSchedules);

                    driverSchedule.RouteRoutines.Add(routeSchedule);
                }
            }

            var result = new PagingViewModel<List<DriverScheduleViewModel>>()
            {
                Items = driverSchedules,
                TotalItemsCount = paging.TotalItemsCount,
                Page = paging.Page,
                PageSize = paging.PageSize,
                TotalPagesCount = paging.TotalPagesCount
            };

            return success.SetData(result);
        }

        private List<T> ConvertTo<T>(List<dynamic> list) => ((List<object>)Convert.ChangeType(list, list.GetType())).OfType<T>().ToList();

        Func<dynamic, bool> ValidTripStatus => x => x.TripStatus != BookingDetailDrivers.TripStatus.Completed &&
                                    x.TripStatus != BookingDetailDrivers.TripStatus.Cancelled;

        private static double CalculateDistanceFromStartToEndStation(List<RouteStation> routeStations, int startStationId, int endStationId, double routeDistance)
        {
            var startStation = routeStations.Where(x => x.StationId == startStationId).FirstOrDefault();
            var endStation = routeStations.Where(x => x.StationId == endStationId).FirstOrDefault();

            if (startStation == null || endStation == null) throw new Exception("Exception not found station in booking.");

            int startIndex = startStation.Index;
            int endIndex = endStation.Index;

            double distance = endStation.DistanceFromFirstStationInRoute - startStation.DistanceFromFirstStationInRoute;
            if (startIndex > endIndex) distance = routeDistance - distance;

            return distance;
        }

        private static string? GetUserPhoneNumber(List<Account> accounts)
            => accounts.Where(x => x.RegistrationType == RegistrationTypes.Phone).FirstOrDefault()?.Registration;

        private static Guid? GetMessageRoomCode(Room? messageRoom) => messageRoom?.Code ?? null;

        private async Task<dynamic> Get(int userId, DateFilterRequest dateFilterRequest, PagingRequest pagingRequest, List<Bookings.Status>? bookingStatus = null ,List<BookingDetails.Status>? statuses = null, bool isOrderAscending = true)
        {
            var bookingDetails = UnitOfWork.BookingDetails
                .List(bd => bd.Booking.UserId == userId);

            if (bookingStatus != null && bookingStatus.Any())
                bookingDetails = bookingDetails
                    .Where(bd => bookingStatus.Contains(bd.Booking.Status));

            if (statuses != null && statuses.Any())
                bookingDetails = bookingDetails
                    .Where(bd => statuses.Contains(bd.Status));

            if (!String.IsNullOrEmpty(dateFilterRequest.FromDate))
            {
                var fromDateParse = DateTimeExtensions.ParseExactDateOnly(dateFilterRequest.FromDate);
                bookingDetails = bookingDetails.Where(x => x.Date >= fromDateParse);
            }
            if (!String.IsNullOrEmpty(dateFilterRequest.ToDate))
            {

                var toDateParse = DateTimeExtensions.ParseExactDateOnly(dateFilterRequest.ToDate);

                bookingDetails = bookingDetails.Where(x => x.Date <= toDateParse);
            }

            bookingDetails = isOrderAscending ? 
                bookingDetails.OrderBy(e => e.Date).ThenBy(e => e.Booking.Time):
                bookingDetails.OrderByDescending(e => e.Date).ThenByDescending(e => e.Booking.Time);

            var paging = bookingDetails.PagingMap<BookingDetail, BookerBookingDetailViewModel>(Mapper, page: pagingRequest.Page, pageSize: pagingRequest.PageSize, AppServices);
            
            return paging;
        }

        public async Task<Response> GetOnGoing(int userId, DateFilterRequest dateFilterRequest, PagingRequest pagingRequest, BookingDetails.Status? status, Response successResponse, Response invalidStatusResponse)
        {
            var bookingDetailStatus = new List<BookingDetails.Status> { BookingDetails.Status.Pending, BookingDetails.Status.Ready, BookingDetails.Status.Started };

            if(status.HasValue)
            {
                if (bookingDetailStatus.Contains(status.Value))
                {
                    bookingDetailStatus.Clear();
                    bookingDetailStatus.Add(status.Value);
                }
                else return invalidStatusResponse;
                
            }

            return successResponse.SetData(
                await Get(
                    userId,
                    dateFilterRequest,
                    pagingRequest,
                    new List<Bookings.Status> { Bookings.Status.PendingMapping, Bookings.Status.Started },
                    bookingDetailStatus));
        }
                

        public async Task<Response> GetHistory(int userId, DateFilterRequest dateFilterRequest, PagingRequest pagingRequest, BookingDetails.Status? status, Response successResponse, Response invalidStatusResponse)
        {
            var bookingDetailStatus = new List<BookingDetails.Status> { BookingDetails.Status.Completed, BookingDetails.Status.Cancelled, BookingDetails.Status.PendingRefund, BookingDetails.Status.CompletedRefund };

            if (status.HasValue)
            {
                if (bookingDetailStatus.Contains(status.Value))
                {
                    bookingDetailStatus.Clear();
                    bookingDetailStatus.Add(status.Value);
                }
                else return invalidStatusResponse;

            }

            return successResponse.SetData(
                await Get(
                    userId,
                    dateFilterRequest,
                    pagingRequest,
                    new List<Bookings.Status> { Bookings.Status.Started, Bookings.Status.Completed, Bookings.Status.CancelledByBooker },
                    bookingDetailStatus,
                    false));
        }

        public Task<BookingDetail?> GetBookingDetailOfBookerByCode(string code, int bookerId)
        {
            return UnitOfWork.BookingDetails.GetBookingDetailByCodeAsync(code)
                .Where(x => x.Booking.UserId == bookerId)
                .FirstOrDefaultAsync();
        }

        public Task<bool> UpdateBookingDetail(BookingDetail bookingDetail)
        {
            return UnitOfWork.BookingDetails.Update(bookingDetail);
        }

        public async Task<Response> GetAll(int userId, Response successResponse)
        {
            var bookingDetails = UnitOfWork.BookingDetails
                .List(bd => bd.Booking.UserId == userId && bd.Status != BookingDetails.Status.Pending)
                .OrderByDescending(bd => bd.Date)
                .ThenByDescending(bd => bd.Booking.Time);

            var bookingDetailVMs = await bookingDetails.MapTo<BookerBookingDetailViewModel>(Mapper, AppServices).ToListAsync();

            return successResponse.SetData(bookingDetailVMs);
        }

        public async Task SetCompletedBookingDetail()
        {
            var nowDateOnly = DateTimeExtensions.NowDateOnly;
            var nowTimeOnly = DateTimeExtensions.NowTimeOnly;

            var bookingDetails = await UnitOfWork.BookingDetails
                .List(e => e.Date <= nowDateOnly && 
                    e.Status != BookingDetails.Status.Cancelled &&
                    e.Status != BookingDetails.Status.Pending)
                .Include(e => e.BookingDetailDrivers)
                .Include(e => e.Booking)
                .ToListAsync();

            foreach(var bookingDetail in bookingDetails)
            {
                if (!bookingDetail.Date.Equals(nowDateOnly) || bookingDetail.Booking.Time.CompareTo(nowTimeOnly) > 1)
                {
                    bookingDetail.Status = BookingDetails.Status.Completed;
                    bookingDetail.BookingDetailDrivers
                        .Where(bdr =>
                            bdr.TripStatus != BookingDetailDrivers.TripStatus.Cancelled)
                        .First().TripStatus = BookingDetailDrivers.TripStatus.Completed;

                    await UnitOfWork.BookingDetails.Update(bookingDetail);
                }
            }
        }

        public Task<BookingDetail?> GetById(int id) =>
            UnitOfWork.BookingDetails
            .List(e => e.Id == id)
            .Include(e => e.Booking)
                .ThenInclude(x => x.User)
            .FirstOrDefaultAsync();

        public async Task<bool?> Refund(Guid code, double amount, BookingDetails.RefundTypes refundType = BookingDetails.RefundTypes.SharingTrip)
        {
            var bookingDetail = await UnitOfWork.BookingDetails
                .List(e => e.Code == code && ((e.Status == BookingDetails.Status.PendingRefund && refundType == BookingDetails.RefundTypes.NotFoundDriver) || 
                    (e.Status == BookingDetails.Status.Completed && refundType == BookingDetails.RefundTypes.SharingTrip)))
                .Include(e => e.Booking)
                .ThenInclude(b => b.WalletTransactions)
                .Include(e => e.Booking)
                .ThenInclude(b => b.User)
                .FirstOrDefaultAsync();

            if (bookingDetail == null) return null;

            var wallet = await AppServices.Wallet.GetWallet(bookingDetail.Booking.UserId);

            if (wallet == null) return null;

            var isSuccess = false;

            try
            {
                switch (bookingDetail.Booking.PaymentMethod)
                {
                    case Payments.PaymentMethods.Momo:
                        //var transaction = bookingDetail.Booking.WalletTransactions
                        //    .Where(trans => trans.Type == WalletTransactions.Types.BookingPaidByMomo && trans.Status == WalletTransactions.Status.Success)
                        //    .FirstOrDefault();

                        //if(transaction != null)
                        //{
                        //    var txnId = long.Parse(transaction.TxnId);

                        //    var response = await AppServices.Payment.MomoRefund(txnId, (long)amount);

                        //    if (response.resultCode != (int)Payments.MomoStatusCodes.Successed) return false;

                        //    var refundTransaction = new WalletTransactionDTO
                        //    {
                        //        Amount = amount,
                        //        BookingId = bookingDetail.BookingId,
                        //        Type = WalletTransactions.Types.BookingRefund,
                        //        TxnId = response.transId.ToString(),
                        //        WalletId = wallet.Id,
                        //        Status = WalletTransactions.Status.Success
                        //    };

                        //    await AppServices.WalletTransaction.Create(refundTransaction);

                        //    isSuccess = true;
                        //}
                        

                        ////return true;
                        //break;
                    case Payments.PaymentMethods.Wallet:
                        await AppServices.Wallet.UpdateBalance(new WalletTransactionDTO
                        {
                            Amount = amount,
                            BookingId = bookingDetail.BookingId,
                            Type = WalletTransactions.Types.BookingRefund,
                            WalletId = wallet.Id,
                            Status = WalletTransactions.Status.Success
                        });

                        isSuccess = true;
                        break;
                        //return true;
                    default: return true;
                }

                if (isSuccess)
                {
                    if(refundType == BookingDetails.RefundTypes.NotFoundDriver)
                        bookingDetail.Status = BookingDetails.Status.CompletedRefund;

                    await UpdateBookingDetail(bookingDetail);

                    var notiDTO = new NotificationDTO()
                    {
                        EventId = Events.Types.CompletedRefund,
                        Type = Notifications.Types.SpecificUser,
                        Token = bookingDetail.Booking.User.FCMToken,
                        UserId = bookingDetail.Booking.User.Id
                    };

                    await AppServices.Notification.SendPushNotification(notiDTO);
                }

                return true;
            }
            catch (Exception e)
            {

            }

            return false;
        }

        public async Task CheckingMappingStatus()
        {
            var theFollowingDay = DateTimeExtensions.NowDateOnly.AddDays(1);

            var bookingDetails = UnitOfWork.BookingDetails
                .List(e => e.Date == theFollowingDay && e.Status == BookingDetails.Status.Pending)
                .Include(e => e.Booking)
                .ThenInclude(b => b.User)
                .ToList()
                .Select(e =>
                {
                    e.Status = BookingDetails.Status.PendingRefund;
                    return e;
                })
                .ToArray();

            if (bookingDetails.Any() && UnitOfWork.BookingDetails.UpdateRange(bookingDetails).Result)
            {
                foreach (var bookingDetail in bookingDetails)
                {
                    var booker = bookingDetail.Booking.User;

                    // send notification to driver
                    var notiDTO = new NotificationDTO()
                    {
                        EventId = Events.Types.RefundBookingDetail,
                        Type = Notifications.Types.SpecificUser,
                        Token = booker.FCMToken,
                        UserId = booker.Id
                    };

                    await AppServices.Notification.SendPushNotification(notiDTO);

                    await AppServices.RedisMQ.Publish(RefundBookingTask.REFUND_QUEUE, new RefundItemDTO
                    {
                        Amount = bookingDetail.Price,
                        Code = bookingDetail.Code,
                        Type = TaskItems.RefundItemTypes.BookingDetail
                    });
                }
            }
            else Logger<BookingDetailDriverService>().LogError("Error: Booking detail null -> cannot update booking detail status to pending refund");
        }

        public async Task CheckingExistTripInDay()
        {
            var today = DateTimeExtensions.NowDateOnly;

            Dictionary<int, User> users = new();

            var bookingDetails = await UnitOfWork.BookingDetails
                .List(e => e.Date == today && e.Status == BookingDetails.Status.Ready)
                .Include(e => e.Booking)
                .ThenInclude(b => b.User)
                .Include(e => e.BookingDetailDrivers.Where(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.NotYet))
                .ThenInclude(bdr => bdr.RouteRoutine)
                .ThenInclude(r => r.User)
                .ToListAsync();

            foreach(var bookingDetail in bookingDetails)
            {
                var booker = bookingDetail.Booking.User;
                var driver = bookingDetail.BookingDetailDrivers.Where(x => x.TripStatus != BookingDetailDrivers.TripStatus.Cancelled)
                    .First().RouteRoutine.User;

                try{ users.Add(booker.Id, booker); } catch (Exception) {}
                try { users.Add(driver.Id, driver); } catch(Exception) {}
            }

            foreach(var user in users.Values)
            {
                // send notification to driver and booker
                var notiDTO = new NotificationDTO()
                {
                    EventId = Events.Types.HaveTripInDay,
                    Type = Notifications.Types.SpecificUser,
                    Token = user.FCMToken,
                    UserId = user.Id
                };

                await AppServices.Notification.SendPushNotification(notiDTO);
            }
        }

        public BookingDetailDriver? GetBookingDetailDriverOfBookingDetail(string bookingDetailCode)
        {
            return UnitOfWork.BookingDetails.GetBookingDetailByCodeAsync(bookingDetailCode)
                .Include(x => x.BookingDetailDrivers).ThenInclude(x => x.RouteRoutine.User)
                .Select(x => x.BookingDetailDrivers.Where(bdd => bdd.TripStatus != BookingDetailDrivers.TripStatus.Cancelled).FirstOrDefault())
                .FirstOrDefault();
        }

        public async Task<FeeViewModel?> CaculateFeeAfterCompleted(Guid code)
        {
            var bookingDetail =
                await UnitOfWork.BookingDetails
                .List(e => e.Code == code && e.Status == BookingDetails.Status.Completed)
                .Include(e => e.Booking)
                .ThenInclude(b => b.StartRouteStation)
                .Include(e => e.BookingDetailDrivers.Where(bdr =>
                                        bdr.TripStatus == BookingDetailDrivers.TripStatus.Completed))
                .FirstOrDefaultAsync();

            if (bookingDetail == null || !bookingDetail.BookingDetailDrivers.Any())
                return null;

            var routeStationDic =
                (await UnitOfWork.Routes
                .List(e => e.Id == bookingDetail.Booking.StartRouteStation.RouteId && e.Status == Routes.Status.Active)
                .Include(e => e.RouteStations)
                .ThenInclude(rs => rs.Station)
                .FirstOrDefaultAsync())?
                .RouteStations
                .ToDictionary(e => e.Id);

            if (routeStationDic == null)
                return null;

            var bookingDetailInTrips =
                (await UnitOfWork.RouteRoutines
                .List(e => e.Id == bookingDetail.BookingDetailDrivers.First().RouteRoutineId)
                .Include(e => e.BookingDetailDrivers.Where(bdr =>
                                    bdr.TripStatus != BookingDetailDrivers.TripStatus.Cancelled &&
                                    bdr.BookingDetail.Date == bookingDetail.Date &&
                                    bdr.BookingDetailId != bookingDetail.Id))
                .ThenInclude(e => e.BookingDetail)
                .ThenInclude(e => e.Booking)
                .FirstOrDefaultAsync())?
                .BookingDetailDrivers
                .Select(bdr => bdr.BookingDetail)
                .ToList();

            if (bookingDetailInTrips == null)
                return null;

            var possibleSharingBookingDetails = PossibleSharingBookingDetails(bookingDetailInTrips, bookingDetail, routeStationDic);

            var steps = routeStationDic.Values
                .Where(routeStation =>
                    routeStation.DistanceFromFirstStationInRoute >= routeStationDic[bookingDetail.Booking.StartRouteStationId].DistanceFromFirstStationInRoute &&
                    routeStation.DistanceFromFirstStationInRoute < routeStationDic[bookingDetail.Booking.EndRouteStationId].DistanceFromFirstStationInRoute)
                .Select(routeStation =>
                {
                    routeStation.NextRouteStation = routeStationDic[routeStation.NextRouteStationId.Value];
                    return routeStation;
                })
                .ToList();

            var sharingStepsInTrip = new List<StepInTripDTO>();

            foreach (var routeStation in steps)
            {
                var stepInTrip = new StepInTripDTO
                {
                    RouteStation = routeStation,
                    Count = 1
                };

                possibleSharingBookingDetails
                    .Where(possibleSharingBookingDetail =>
                        routeStationDic[possibleSharingBookingDetail.Booking.StartRouteStationId].DistanceFromFirstStationInRoute <= routeStation.DistanceFromFirstStationInRoute &&
                        routeStationDic[possibleSharingBookingDetail.Booking.EndRouteStationId].DistanceFromFirstStationInRoute >= routeStation.NextRouteStation.DistanceFromFirstStationInRoute)
                    .ToList()
                    .ForEach(possibleSharingBookingDetail =>
                    {
                        stepInTrip.Count++;
                    });

                if(stepInTrip.Count > 1)
                    sharingStepsInTrip.Add(stepInTrip);
            }

            double discount = 0;

            var discountPerEachSharingCase = await AppServices.Setting.GetValue<double>(Settings.DiscountPerEachSharingCase, 0.1);
            var thresholdDiscountPerEachSharingCase = await AppServices.Setting.GetValue<double>(Settings.ThresholdDiscountPerEachSharingCase, 0.5);

            foreach (var sharingStep in sharingStepsInTrip)
            {
                var distance = sharingStep.RouteStation.NextRouteStation.DistanceFromFirstStationInRoute - sharingStep.RouteStation.DistanceFromFirstStationInRoute;
                var discountPercent = sharingStep.Count * discountPerEachSharingCase;
                if (discountPercent > thresholdDiscountPerEachSharingCase) discountPercent = thresholdDiscountPerEachSharingCase;

                discount += ((await AppServices.Fare.CaculateFeeByDistance(bookingDetail.Booking.VehicleTypeId, distance, bookingDetail.Booking.Time, false, false)).TotalFee * discountPercent);
            }

            discount = Fee.FloorToHundreds(discount);

            return new FeeViewModel
            {
                Fee = bookingDetail.Price,
                DiscountFee = discount,
                TotalFee = bookingDetail.Price - discount
            };
        }

        public List<BookingDetail> PossibleSharingBookingDetails(List<BookingDetail> mappedBookingDetails, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            var curStartStation = routeStationDic[bookingDetail.Booking.StartRouteStationId];
            var curEndStation = routeStationDic[bookingDetail.Booking.EndRouteStationId];

            //var filterMappedBookingDetails = mappedBookingDetails
            //    .Where(mappedBookingDetail =>
            //        !(((mappedBookingDetail.Booking.Time - bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration)).TotalMinutes >= Bookings.AllowedMappingTimeRange) ||
            //           (bookingDetail.Booking.Time - mappedBookingDetail.Booking.Time.AddMinutes(mappedBookingDetail.Booking.Duration)).TotalMinutes >= Bookings.AllowedMappingTimeRange))
            //    .ToList();

            return mappedBookingDetails
                    .Where(mappedBookingDetail =>
                        !(curStartStation.DistanceFromFirstStationInRoute >= routeStationDic[mappedBookingDetail.Booking.EndRouteStationId].DistanceFromFirstStationInRoute ||
                          curEndStation.DistanceFromFirstStationInRoute <= routeStationDic[mappedBookingDetail.Booking.StartRouteStationId].DistanceFromFirstStationInRoute))
                    .OrderBy(mappedBookingDetail => mappedBookingDetail.Booking.Time)
                    .ToList();
        }

        public Task<BookerBookingDetailViewModel?> GetBookerViewModelByCode(Guid code)
        {
            return UnitOfWork.BookingDetails.GetBookingDetailByCodeAsync(code.ToString())
                .MapTo<BookerBookingDetailViewModel>(Mapper, AppServices)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Cancel(List<int> ids)
        {
            var bookingDetails = await UnitOfWork.BookingDetails
                .List(e => ids.Contains(e.Id))
                .Include(e => e.BookingDetailDrivers)
                .ToListAsync();

            bookingDetails = bookingDetails.Select(e =>
            {
                e.Status = BookingDetails.Status.Pending;
                e.MessageRoom = null;
                e.MessageRoomId = null;
                var bookingDetailDriver = e.BookingDetailDrivers.Where(x => x.TripStatus == BookingDetailDrivers.TripStatus.NotYet).FirstOrDefault();
                if (bookingDetailDriver != null)
                    bookingDetailDriver.TripStatus = BookingDetailDrivers.TripStatus.Cancelled;

                return e;
            })
            .ToList();

            return await UnitOfWork.BookingDetails.UpdateRange(bookingDetails.ToArray());

        } 

        public async Task<Response> Cancel(Guid code, Response successResponse, Response notFoundResponse, Response notAllowResponse, Response failedResponse)
        {
            var bookingDetail = await UnitOfWork.BookingDetails
                .List(e => e.Code == code)
                .Include(e => e.BookingDetailDrivers)
                .ThenInclude(bdr => bdr.RouteRoutine)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync();

            if (bookingDetail == null) return notFoundResponse;

            var allowedBookerCancelTripTime = await AppServices.Setting.GetValue<TimeOnly>(Settings.AllowedBookerCancelTripTime, new TimeOnly(19, 45));

            var tomorrowDateOnly = DateTimeExtensions.NowDateOnly.AddDays(1);
            var nowTimeOnly = DateTimeExtensions.NowTimeOnly;

            if (bookingDetail.Date < tomorrowDateOnly || (bookingDetail.Date == tomorrowDateOnly && nowTimeOnly > allowedBookerCancelTripTime))
                return notAllowResponse;

            var tradeDisountForBookerCancelTrip = await AppServices.Setting.GetValue(Settings.TradeDisountForBookerCancelTrip, 0.1);
            if (bookingDetail.Status == BookingDetails.Status.Pending) tradeDisountForBookerCancelTrip = 0;

            bookingDetail.Status = BookingDetails.Status.PendingRefund;
            //bookingDetail.DeletedAt = DateTimeOffset.Now;

            var bookingDetailDriver = bookingDetail.BookingDetailDrivers.Where(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.NotYet).FirstOrDefault();

            if(bookingDetailDriver != null)

                bookingDetailDriver.TripStatus = BookingDetailDrivers.TripStatus.Cancelled;

            if (!await UnitOfWork.BookingDetails.Update(bookingDetail))
                return failedResponse;

            

            await AppServices.RedisMQ.Publish(RefundBookingTask.REFUND_QUEUE, new RefundItemDTO 
            { 
                Code = bookingDetail.Code, 
                Amount = (1- tradeDisountForBookerCancelTrip) * bookingDetail.Price, 
                Type = TaskItems.RefundItemTypes.BookingDetail 
            });

            if(bookingDetailDriver != null)
            {
                await AppServices.RedisMQ.Publish(MappingBookingTask.MAPPING_QUEUE, new MappingItemDTO { Id = bookingDetailDriver.RouteRoutineId, Type = TaskItems.MappingItemTypes.RouteRoutine });
                var driver = bookingDetailDriver.RouteRoutine.User;

                var notiDTO = new NotificationDTO()
                {
                    EventId = Events.Types.CancelByBooker,
                    Type = Notifications.Types.SpecificUser,
                    Token = driver.FCMToken,
                    UserId = driver.Id
                };

                await AppServices.Notification.SendPushNotification(notiDTO);
            }     

            return successResponse;
        }
    }
}
