using API.Extensions;
using API.Models;
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

namespace API.Services
{
    public class BookingDetailService: BaseService, IBookingDetailService
    {

        public BookingDetailService(IAppServices appServices) : base(appServices)
        {
        }

        public List<BookingDetail> GenerateBookingDetail(Booking booking, double feePerTrip)
        {
            List<BookingDetail> bookingDetails = new();
            for(var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
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


            var bookingDetail = await bookingDetailsIQueryable.MapTo<BookerBookingDetailViewModel>(Mapper,AppServices).FirstOrDefaultAsync();

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
                var detailsByDay = bookingDetails.Where(x => x.Date == driverSchedule.Date).OrderBy(x => x.Booking.Time);

                var routes = (await detailsByDay.Select(x => x.Booking.StartRouteStation.Route).ToListAsync()).DistinctBy(x => x.Id);

                foreach (var route in routes)
                {
                    RouteScheduleViewModel routeSchedule = new()
                    {
                        RouteCode = route.Code.ToString()
                    };

                    var detailsInRoute = detailsByDay.Where(x => x.Booking.StartRouteStation.RouteId == route.Id);

                    var schedules = detailsInRoute.Select(x => new ScheduleBookingDetailViewModel
                    {
                        BookingDetailDriverCode = x.BookingDetailDrivers.Where(bdd => bdd.Status != BookingDetailDrivers.Status.Cancelled && 
                            bdd.DriverId == driverId).OrderByDescending(x => x.CreatedAt).Select(x => x.Code).FirstOrDefault(),
                        TripStatus = x.BookingDetailDrivers.Where(bdd => bdd.Status != BookingDetailDrivers.Status.Cancelled &&
                            bdd.DriverId == driverId).OrderByDescending(x => x.CreatedAt).Select(x => x.TripStatus).FirstOrDefault(),
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
                        Users = new()
                        {
                            new()
                            {
                                Code = x.Booking.User.Code,
                                Name = x.Booking.User.Name,
                                Gender = x.Booking.User.Gender,
                                PhoneNumber = GetUserPhoneNumber(x.Booking.User.Accounts),
                                ChattingRoomCode = GetMessageRoomCode(x.MessageRoom),
                                PaymentMethod = x.Booking.PaymentMethod,
                                PaymentStatus = x.Booking.Status
                            }
                        }
                    });

                    // add schedules
                    routeSchedule.Schedules.AddRange(schedules);

                    var startStepInSchedules = schedules.Select(x => new StepScheduleViewModel()
                    {
                        BookingDetailDriverCode = x.BookingDetailDriverCode,
                        StationCode = x.StartStation.Code,
                        StationName = x.StartStation.Name,
                        TripStatus = x.TripStatus,
                        UserName = x.Users[0].Name,
                        Type = BookingDetailDrivers.StepScheduleType.PickUp,
                        Index = x.StartStation.Index
                    }).ToList();

                    var endStepInSchedules = schedules.Select(x => new StepScheduleViewModel()
                    {
                        BookingDetailDriverCode = x.BookingDetailDriverCode,
                        StationCode = x.BookingDetailDriverCode,
                        StationName = x.StartStation.Name,
                        TripStatus = x.TripStatus,
                        UserName = x.Users[0].Name,
                        Type = BookingDetailDrivers.StepScheduleType.DropOff,
                        Index = x.EndStation.Index
                    }).ToList();

                    var stepInSchedules = startStepInSchedules.Concat(endStepInSchedules).OrderBy(x => x.Index).AsEnumerable();

                    routeSchedule.Steps.AddRange(stepInSchedules);

                    driverSchedule.Routes.Add(routeSchedule);
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

        private async Task<dynamic> Get(int userId, DateFilterRequest dateFilterRequest, List<BookingDetails.Status>? statuses = null)
        {
            var bookingDetails = UnitOfWork.BookingDetails
                .List(bd => bd.Booking.UserId == userId);

            if(statuses != null && statuses.Any())
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

            var bookingDetailVMs = await bookingDetails.MapTo<BookerBookingDetailViewModel>(Mapper,AppServices).ToListAsync();

            return bookingDetailVMs
                .GroupBy(x => x.Date)
                .ToDictionary(e => e.Key, e => e)
                .OrderBy(e => e.Key)
                .Select(e => new
                {
                    Date = e.Key,
                    Items = e.Value
                });
        }

        public async Task<Response> GetOnGoing(int userId, DateFilterRequest dateFilterRequest, Response successResponse)
            => successResponse.SetData(await Get(userId, dateFilterRequest, new List<BookingDetails.Status> { BookingDetails.Status.Ready, BookingDetails.Status.Started }));

        public async Task<Response> GetHistory(int userId, DateFilterRequest dateFilterRequest, Response successResponse)
            => successResponse.SetData(await Get(userId, dateFilterRequest, new List<BookingDetails.Status> { BookingDetails.Status.Completed, BookingDetails.Status.Cancelled }));

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
    }
}
