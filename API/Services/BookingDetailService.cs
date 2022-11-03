using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using API.Services.Constract;
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

        public List<BookingDetail> GenerateBookingDetail(Booking booking, double feePerTrip)
        {
            List<BookingDetail> bookingDetails = new();
            for (var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
            {
                bookingDetails.Add(new BookingDetail
                {
                    Booking = booking,
                    Date = day,
                    Price = Fee.RoundToThousands(feePerTrip),
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
            var bookingDetails = UnitOfWork.BookingDetails.GetBookingDetailsByDriverId(driverId);

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
                //var detailsByDay = bookingDetails.Where(x => x.Date == driverSchedule.Date).OrderBy(x => x.Booking.Time);

                //var routes = (detailsByDay.Where(bd => bd.BookingDetailDrivers.Where(bdd => bdd.TripStatus != BookingDetailDrivers.TripStatus.Cancelled && bdd.TripStatus != BookingDetailDrivers.TripStatus.Completed).Any())).Select(x => new BookingRoutineDTO { Route = x.Booking.StartRouteStation.Route, Date = x.Date, Time = x.Booking.Time}).ToList().DistinctBy(x => x.Route.Id).ToList();

                var detailRoutines = new List<BookingDetailRoutineDTO>();
               
                UnitOfWork.RouteRoutines.GetAllRouteRoutine(driverId).Include(x => x.Route).OrderBy(x => x.StartTime).ToList()
                    .Where(x =>
                    {
                        var details = bookingDetails.Where(x => x.Date == driverSchedule.Date).OrderBy(x => x.Booking.Time).Where(bd => bd.Booking.StartRouteStation.Route.Id == x.RouteId && x.StartAt <= bd.Date && bd.Date <= x.EndAt && x.StartTime <= bd.Booking.Time && bd.Booking.Time <= x.EndTime);
                        
                        if (details.Any())
                        detailRoutines.Add(new()
                        {
                            Routine = x,
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

                    //var detailsInRoute = detailsByDay.Where(x => x.Booking.StartRouteStation.RouteId == routine.RouteId);
                    var detailsInRouteRoutine = routineDetail.BookingDetails
                        .Where(x => x.Booking.StartRouteStation.RouteId == routine.RouteId)
                        .Where(x => x.Status != BookingDetails.Status.Cancelled && x.Status != BookingDetails.Status.Completed); //detailsByDay.Where(x => x.Booking.StartRouteStation.RouteId == routine.RouteId);

                    if (!detailsInRouteRoutine.Any()) continue;

                    var schedules = detailsInRouteRoutine.Select(x => new ScheduleBookingDetailViewModel
                    {
                        BookingDetailDriverCode = x.BookingDetailDrivers.Where(bdd => bdd.DriverId == driverId)
                            .Where(bdd => bdd.TripStatus != BookingDetailDrivers.TripStatus.Cancelled && bdd.TripStatus != BookingDetailDrivers.TripStatus.Completed)
                            .OrderByDescending(x => x.CreatedAt)
                            .Select(x => x.Code).FirstOrDefault(),
                        TripStatus = x.BookingDetailDrivers.Where(bdd => bdd.DriverId == driverId)
                            .Where(bdd => bdd.TripStatus != BookingDetailDrivers.TripStatus.Cancelled && bdd.TripStatus != BookingDetailDrivers.TripStatus.Completed)
                            .OrderByDescending(x => x.CreatedAt)
                            .Select(x => x.TripStatus).FirstOrDefault(),
                        Time = x.Booking.Time,
                        StartStation = new()
                        {
                            Code = x.Booking.StartRouteStation.Station.Code,
                            Name = x.Booking.StartRouteStation.Station.Name,
                            Address = x.Booking.StartRouteStation.Station.Address,
                            Index = x.Booking.StartRouteStation.Index
                        },
                        EndStation = new()
                        {
                            Code = x.Booking.EndRouteStation.Station.Code,
                            Name = x.Booking.EndRouteStation.Station.Name,
                            Address = x.Booking.EndRouteStation.Station.Address,
                            Index = x.Booking.EndRouteStation.Index
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
                    //schedules.ToList();
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
                        Time = x.Time
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
                        Time = x.Time
                    });

                    var stepInSchedules = startStepInSchedules.Concat(endStepInSchedules).OrderBy(x => x.Time).ThenBy(x => x.Index)
                        .Where(ValidTripStatus).ToList();

                    //var obj = ((List<object>)Convert.ChangeType(stepInSchedules, stepInSchedules.GetType())).OfType<StepScheduleViewModel>().ToList();

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

            var paging = bookingDetails.Paging(page: pagingRequest.Page, pageSize: pagingRequest.PageSize);

            var result = new PagingViewModel<List<BookerBookingDetailViewModel>>()
            {
                Items = await paging.Items.MapTo<BookerBookingDetailViewModel>(Mapper, AppServices).ToListAsync(),
                TotalItemsCount = paging.TotalItemsCount,
                Page = paging.Page,
                PageSize = paging.PageSize,
                TotalPagesCount = paging.TotalPagesCount
            };

            return result;
        }

        public async Task<Response> GetOnGoing(int userId, DateFilterRequest dateFilterRequest, PagingRequest pagingRequest,Response successResponse)
            => successResponse.SetData(
                await Get(
                    userId, 
                    dateFilterRequest, 
                    pagingRequest,
                    new List<Bookings.Status> { Bookings.Status.PendingMapping, Bookings.Status.Started},
                    new List<BookingDetails.Status> { BookingDetails.Status.Pending ,BookingDetails.Status.Ready }));

        public async Task<Response> GetHistory(int userId, DateFilterRequest dateFilterRequest, PagingRequest pagingRequest, Response successResponse)
            => successResponse.SetData(
                await Get(
                    userId, 
                    dateFilterRequest, 
                    pagingRequest, 
                    new List<Bookings.Status> { Bookings.Status.Started ,Bookings.Status.Completed, Bookings.Status.CancelledByBooker},
                    new List<BookingDetails.Status> { BookingDetails.Status.Completed, BookingDetails.Status.Cancelled }, 
                    false));

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
            .ThenInclude(b => b.User)
            .FirstOrDefaultAsync();
    }
}
