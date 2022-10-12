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

        //public List<BookingDetail> GenerateBookingDetail(Booking booking)
        //{
        //    List<BookingDetail> bookingDetails = new();
        //    if (booking.Type == Bookings.Types.Monthly)
        //    {
        //        var daysOfMonthHashSet = booking.Days.DaysOfMonth.ToHashSet();

        //        var startYear = booking.StartAt.Year;
        //        var endYear = booking.EndAt.Year;

        //        var bookingDetailsDic = new Dictionary<DateOnly, BookingDetail>();

        //        for(var year = startYear; year <= endYear; year++)
        //        {
        //            var startMonth = booking.StartAt.Month;
        //            var endMonth = booking.EndAt.Month;
        //            if (year != endYear)
        //            {
        //                endMonth = 12;
        //            }

        //            if(year != startYear)
        //            {
        //                startMonth = 1;
        //            }

        //            for(var month = startMonth; month <= endMonth; month++)
        //            {
        //                var totalApplyChangeInNextMonth = 0;
        //                foreach (var day in daysOfMonthHashSet)
        //                {                         
        //                    try
        //                    {
        //                        DateOnly date = new DateOnly(year, month, day);
        //                        bookingDetailsDic.Add(date,new BookingDetail
        //                        {
        //                            Booking = booking,
        //                            Date = date,
        //                        });
        //                    }
        //                    catch
        //                    {
        //                        if(booking.Option == Bookings.Options.ChangeToNextDayOfNextMonth)
        //                        {
        //                            totalApplyChangeInNextMonth++;
        //                        }
        //                    }                            
        //                }

        //                for (var day = 1; day <= totalApplyChangeInNextMonth; day++)
        //                {
        //                    DateOnly date = new DateOnly(year, month + 1, day);                               
        //                    bookingDetailsDic.Add(date, new BookingDetail
        //                    {
        //                        Booking = booking,
        //                        Date = date,
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var daysOfWeekHashSet = booking.Days.DaysOfWeek.ToHashSet();
        //        for (var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
        //        {
        //            if (daysOfWeekHashSet.Contains(day.DayOfWeek))
        //            {
        //                bookingDetails.Add(new BookingDetail
        //                {
        //                    Booking = booking,
        //                    Date = day,
        //                });
        //            }
        //        };
        //    }
        //    return bookingDetails;
        //}

        public List<BookingDetail> GenerateBookingDetail(Booking booking)
        {
            List<BookingDetail> bookingDetails = new();
            var price = booking.TotalPrice / Fee.TotalDays(booking.StartAt, booking.EndAt);
            for(var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
            {
                bookingDetails.Add(new BookingDetail
                {
                    Booking = booking,
                    Date = day,
                    Price = price
                });
            }
            return bookingDetails;
        }

        public async Task<Response> GetNextBookingDetail(int userId, Response successResponse)
        {
            var bookingDetailsIQueryable = UnitOfWork.BookingDetails.List(b => b.Booking.UserId == userId && b.Status != StatusTypes.BookingDetail.Completed)
                                                                .OrderBy(b => b.Date)
                                                                .ThenBy(b => b.Booking.Time);


            var bookingDetail = await Mapper.ProjectTo<BookerBookingDetailViewModel>(bookingDetailsIQueryable).FirstOrDefaultAsync();

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
                        Time = x.Booking.Time,
                        StartStation = new()
                        {
                            Code = x.Booking.StartRouteStation.Station.Code,
                            Name = x.Booking.StartRouteStation.Station.Name,
                            Address = x.Booking.StartRouteStation.Station.Address
                        },
                        EndStation = new()
                        {
                            Code = x.Booking.EndRouteStation.Station.Code,
                            Name = x.Booking.EndRouteStation.Station.Name,
                            Address = x.Booking.EndRouteStation.Station.Address
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

                    routeSchedule.Schedules.AddRange(schedules);

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
    }
}
