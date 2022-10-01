using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BookingDetailService: IBookingDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            for(var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
            {
                bookingDetails.Add(new BookingDetail
                {
                    Booking = booking,
                    Date = day
                });
            }
            return bookingDetails;
        }

        public async Task<Response> GetNextBookingDetail(int userId, Response successResponse)
        {
            var bookingDetailsIQueryable = _unitOfWork.BookingDetails.List(b => b.Booking.UserId == userId && b.Status != StatusTypes.BookingDetail.Completed)
                                                                .OrderBy(b => b.Date)
                                                                .ThenBy(b => b.Booking.Time);


            var bookingDetail = await _mapper.ProjectTo<BookerBookingDetailViewModel>(bookingDetailsIQueryable).FirstOrDefaultAsync();

            return successResponse.SetData(bookingDetail);
        }

        public async Task<Response> GetBookingsOfDriver(int driverId, Response success, PagingRequest? request = null)
        {
            var bookingDetails = _unitOfWork.BookingDetails.GetBookingDetailsByDriverId(driverId).OrderByDescending(x => x.Date);

            List<DriverScheduleViewModel> driverSchedules = new();

            IQueryable<DateOnly> scheduleDates = bookingDetails.Select(x => x.Date).Distinct();

            if (scheduleDates == null)
            {
                return success;
            }

            var paging = scheduleDates.Paging(page: request.Page, pageSize: request.PageSize);

            if (request != null) scheduleDates = paging.Items;

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

                var routes = detailsByDay.Select(x => x.Booking.Route).ToList().DistinctBy(x => x.Id);

                foreach (var route in routes)
                {
                    RouteScheduleViewModel routeSchedule = new()
                    {
                        RouteCode = route.Code.ToString()
                    };

                    var detailsInRoute = detailsByDay.Where(x => x.Booking.RouteId == route.Id);

                    var startStations = detailsInRoute.Select(x => new StopStationViewModel
                    {
                        Time = x.Booking.Time,
                        Code = x.Booking.StartStationCode.ToString()
                    });

                    var endStations = detailsInRoute.Select(x => new StopStationViewModel
                    {
                        Time = CalculateTimeToEndStation(x.Booking.Time, x.Booking.Route.RouteStations.Where(y => y.Station.Code == x.Booking.StartStationCode).FirstOrDefault(), x.Booking.Route.RouteStations.Where(y => y.Station.Code == x.Booking.EndStationCode).FirstOrDefault(), x.Booking.Route.Duration),
                        Code = x.Booking.EndStationCode.ToString()
                    });

                    var stopStations = (await startStations.ToListAsync()).Union(endStations).DistinctBy(x => x.Time).OrderBy(x => x.Time);

                    routeSchedule.StopStations.AddRange(stopStations);

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

        private static TimeOnly CalculateTimeToEndStation(TimeOnly startTime, RouteStation? startStation, RouteStation? endStation, double routeDuration)
        {
            if (startStation == null || endStation == null) throw new Exception("Exception not found station in booking.");

            int startIndex = startStation.Index;
            int endIndex = endStation.Index;

            double duration = endStation.DurationFromFirstStationInRoute - startStation.DurationFromFirstStationInRoute;
            if (startIndex > endIndex) duration = routeDuration - duration;

            return startTime.AddMinutes(duration / 60);
        }
    }
}
