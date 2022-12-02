using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using API.TaskQueues.TaskResolver;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RouteRoutineService : BaseService, IRouteRoutineService
    {
        public RouteRoutineService(IAppServices appServices) : base(appServices)
        {
        }

        public bool CheckValidRoutineForRoute(CreateRouteRoutineRequest request)
        {
            var driverRouteRoutineCurrent = UnitOfWork.RouteRoutines.GetActiveRoutines(request.UserId)
                    .Where(x => x.EndAt >= DateTimeExtensions.NowDateOnly);

            if (driverRouteRoutineCurrent == null || !driverRouteRoutineCurrent.Any()) return true;

            return !driverRouteRoutineCurrent.ToList()
                .Where(x => (request.StartAtParsed <= x.EndAt && request.EndAtParsed >= x.StartAt && request.StartTimeParsed < x.EndTime.RoundUp(5) && request.EndTimeParsed.RoundUp(5) > x.StartTime))
                .Any();
        }

        public Task<List<RouteRoutine>> CreateRouteRoutines(List<RouteRoutine> routines) => UnitOfWork.RouteRoutines.Add(routines);

        public async Task<Response> CreateRouteRoutine(CreateRouteRoutineRequest request, Response success, Response failed)
        {
            var newRouteRoutineData = new RouteRoutine()
            {
                RouteId = request.RouteId,
                StartTime = request.StartTimeParsed,
                EndTime = request.EndTimeParsed,
                StartAt = request.StartAtParsed,
                EndAt = request.EndAtParsed,
                UserId = request.UserId
            };

            if (newRouteRoutineData == null) return failed;

            await UnitOfWork.CreateTransactionAsync();

            var routeRoutineCreated = await UnitOfWork.RouteRoutines.Add(newRouteRoutineData);

            if (routeRoutineCreated == null)
            {
                await UnitOfWork.Rollback();
                return failed;
            }

            var viewModel = UnitOfWork.RouteRoutines.List(x => x.Id == routeRoutineCreated.Id).MapTo<RouteRoutineViewModel>(Mapper);

            if (viewModel == null)
            {
                await UnitOfWork.Rollback();
                return failed;
            }
            await UnitOfWork.CommitAsync();

            await AppServices.RedisMQ.Publish(MappingBookingTask.MAPPING_QUEUE, new MappingItemDTO { Id = routeRoutineCreated.Id, Type = TaskItems.MappingItemTypes.RouteRoutine });
            return success.SetData(viewModel);
        }

        public async Task<InvalidRoutineViewModel?> CheckValidDistanceNewRoutine(CreateRouteRoutineRequest request)
        {
            var driverRouteRoutine = UnitOfWork.RouteRoutines.GetActiveRoutines(request.UserId)
                .Include(x => x.Route)
                .ThenInclude(x => x.RouteStations)
                .ThenInclude(x => x.Station)
                .Where(x => x.EndAt >= DateTimeExtensions.NowDateOnly)
                .Where(x => request.StartAtParsed <= x.EndAt && request.EndAtParsed >= x.StartAt);

            var timelines = new List<TimelineDTO>();

            foreach(var routeRoutine in driverRouteRoutine)
            {
                timelines.Add(new()
                {
                    Station = routeRoutine.Route.RouteStations.MinBy(x => x.Index).Station,
                    Time = routeRoutine.StartTime,
                    Routine = routeRoutine
                });
                timelines.Add(new()
                {
                    Station = routeRoutine.Route.RouteStations.MaxBy(x => x.Index).Station,
                    Time = routeRoutine.EndTime,
                    Routine = routeRoutine
                });
            }

            timelines = timelines.DistinctBy(x => x.Time).OrderBy(x => x.Time).ToList();

            var newRouteStations = UnitOfWork.Routes.List(x => x.Code.ToString() == request.RouteCode).Include(x => x.RouteStations).ThenInclude(x => x.Station).FirstOrDefault().RouteStations;
            
            var newStartStation = newRouteStations.MinBy(x => x.Index).Station;
            var newEndStation = newRouteStations.MaxBy(x => x.Index).Station;

            for (var i = 0; i <= timelines.Count; i++)
            {
                TimeOnly endTimePre;
                TimeOnly startTimeNext;

                Station? endStationPre = null;
                Station? startStationNext = null;

                RouteRoutine? routinePre = null;
                RouteRoutine? routineNext = null;

                try { 
                    endTimePre = timelines[i - 1].Time; 
                    endStationPre = timelines[i - 1].Station; 
                    routinePre = timelines[i - 1].Routine; 
                } 
                catch { 
                    endTimePre = new TimeOnly(0, 0, 1); 
                }

                try { 
                    startTimeNext = timelines[i].Time; 
                    startStationNext = timelines[i].Station;
                    routineNext = timelines[i].Routine;
                } 
                catch { 
                    startTimeNext = new TimeOnly(23, 59, 59); 
                }

                if (endTimePre < request.StartTimeParsed && request.EndTimeParsed < startTimeNext)
                {
                    var timeSpanRounded = await AppServices.Setting.GetValue(Settings.TimeSpanRounded, 5);
                    var timeSpanBuffer = await AppServices.Setting.GetValue(Settings.TimeSpanBufferToCreateRoutine, 5);
                    if (endStationPre != null)
                    {
                        var disAndDur = await AppServices.RapidApi.CalculateDistanceAndDurationFrom2Station(endStationPre, newStartStation);
                        var validTimePre = endTimePre.AddMinutes(disAndDur.Value / 60)
                            .RoundUp(timeSpanRounded)
                            .AddMinutes(timeSpanBuffer);

                        if (validTimePre > request.StartTimeParsed)
                        {
                            return new InvalidRoutineViewModel() 
                            {
                                ConflictedRoutine = Mapper.Map<RouteRoutineViewModel>(routinePre),
                                ValidTime = validTimePre,
                                Compare = "New routine must start after"
                            };
                        }
                    }
                    if (startStationNext != null)
                    {
                        var disAndDur = await AppServices.RapidApi.CalculateDistanceAndDurationFrom2Station(newEndStation, startStationNext);
                        
                        var validTimeNext = startTimeNext.AddMinutes(- disAndDur.Value / 60)
                            .RoundDown(timeSpanRounded)
                            .AddMinutes(- timeSpanBuffer);

                        if (validTimeNext < request.EndTimeParsed)
                        {
                            return new InvalidRoutineViewModel()
                            {
                                ConflictedRoutine = Mapper.Map<RouteRoutineViewModel>(routineNext),
                                ValidTime = validTimeNext,
                                Compare = "New routine must end before"
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task<Response?> CheckTimeToCreateRoutine(CreateRouteRoutineRequest request)
        {
            var timelineToCreate = 
                DateTimeExtensions.ParseExactTimeOnly(
                    await AppServices.Setting.GetValue(Settings.TimeToCreateTomorrowRoutine, "20:00:00"));

            var nowTimeOnly = DateTimeExtensions.NowTimeOnly;
            var nowDateOnly = DateTimeExtensions.NowDateOnly;

            if (nowTimeOnly < timelineToCreate)
            {
                // can create routine start from tomorrow
                
                if (request.StartAtParsed < nowDateOnly.AddDays(1)) return new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "You can only create route routine from tomorrow."
                };
            } 
            else
            {
                // can create routine start from the day after tomorrow
                if (request.StartAtParsed < nowDateOnly.AddDays(2)) return new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = $"You can only create route routine from the day after tomorrow, now is after {timelineToCreate}."
                };
            }

            return null;
        }

        public async Task<Response?> CheckDateToCreateRoutine(CreateRouteRoutineRequest request)
        {
            var nowDateOnly = DateTimeExtensions.NowDateOnly;
            var firstDayOfNextMonth = new DateOnly(nowDateOnly.AddMonths(1).Year, nowDateOnly.AddMonths(1).Month + 1, 1);
            var lastDayOfNextMonth = firstDayOfNextMonth.AddMonths(1).AddDays(-1);

            var startRoutineMonth = request.StartAtParsed.Month;
            var endRoutineMonth = request.EndAtParsed.Month;
            var startRoutineYear = request.StartAtParsed.Year;
            var endRoutineYear = request.EndAtParsed.Year;

            if (startRoutineMonth != endRoutineMonth || startRoutineYear != endRoutineYear) return new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "You just sign routine with start date and end date in the same month."
            };

            var dayForNextMonthRoutine = firstDayOfNextMonth.AddDays(- await AppServices.Setting.GetValue(Settings.LastDayNumberForNextMonthRoutine, 7));

            // before last 7 days of this month, driver can only sign routine in this month.
            if (nowDateOnly < dayForNextMonthRoutine)
            {
                if (nowDateOnly.Month != startRoutineMonth)
                {
                    return new()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = $"At this time, you just can sign routine in this month only. For the next month routine, back to sign routine after {dayForNextMonthRoutine}"
                    };
                }
            } 
            else
            {
                if (nowDateOnly.Month != startRoutineMonth && nowDateOnly.Month + 1 != startRoutineMonth) return new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "You just sign routine for the rest of this month or the whole next month."
                };
            }

            return null;
        }

        public async Task<Response> GetRouteRoutineOfDriver(int driverId, Response success)
        {
            var routeRoutines =
                await UnitOfWork.RouteRoutines.GetAllRouteRoutine(driverId)
                    .MapTo<RouteRoutineViewModel>(Mapper)
                    .ToListAsync();

            return success.SetData(routeRoutines);
        }

        public Task<List<RouteRoutine>> GetByRouteId(int routeId) => 
            UnitOfWork.RouteRoutines
            .List(routeRoutine => 
                routeRoutine.RouteId == routeId && 
                routeRoutine.Status == RouteRoutines.Status.Active)
            .Include(e => e.User)
            .ThenInclude(u => u.Vehicle)
            .Include(e => e.User)
            .Include(u => u.BookingDetailDrivers)
            .ThenInclude(bdr => bdr.BookingDetail)
            .ThenInclude(bd => bd.Booking)
            .ToListAsync();

        public async Task<List<RouteRoutine>> GetRouteRoutineFitBookingCondition(Booking booking)
        {

            var routeRoutines = await UnitOfWork.RouteRoutines
                .List(e => e.StartTime <= booking.Time && 
                           e.EndTime > booking.Time &&
                           !(e.EndAt < booking.StartAt || e.StartAt > booking.EndAt) &&
                           e.Status == RouteRoutines.Status.Active) 
                .ToListAsync();

            return routeRoutines
                .Where(e => e.StartTime.AddMinutes(booking.StartRouteStation.DurationFromFirstStationInRoute / 60).ToTimeSpan(booking.Time).TotalMinutes <= Bookings.AllowedMappingTimeRange)
                .ToList();
        }

        public async Task<dynamic> GetMappedBookingDetailDriverByRouteRoutine() // for booking mapping test
        {
            var routeRoutines = await UnitOfWork.RouteRoutines
            .List(routeRoutine =>
                routeRoutine.Status == RouteRoutines.Status.Active)
            .Include(e => e.User)
            .ThenInclude(u => u.Vehicle)
            .ThenInclude(v => v.VehicleType)
            .Include(e => e.User)
            .Include(u => u.BookingDetailDrivers)
            .ThenInclude(bdr => bdr.BookingDetail)
            .ThenInclude(bd => bd.Booking)
            .Include(b => b.Route)
            .ThenInclude(r => r.RouteStations)
            .ThenInclude(rs => rs.Station)
            .ToListAsync();

            var totalBookingDetails = 0;
            var totalBookingDetailDrivers = 0;
            var totalBookingDetailCanShares = 0;
            var totalBookingDetailShares = 0;
            var totalBookingDetailNotShares = 0;
            var totalConflictSharingConditionCases = 0;

            totalBookingDetails = await UnitOfWork.BookingDetails.List(bookingDetail => bookingDetail.Status != BookingDetails.Status.Cancelled).CountAsync();

            foreach(var routeRoutine in routeRoutines)
            {
                var startDate = routeRoutine.StartAt;
                var endDate = routeRoutine.EndAt;
                var startTime = routeRoutine.StartTime;
                var endTime = routeRoutine.EndTime;


                totalBookingDetailDrivers += routeRoutine.BookingDetailDrivers.Count;
                totalBookingDetailCanShares += routeRoutine.BookingDetailDrivers.Where(bookingDetailDriver => bookingDetailDriver.BookingDetail.Booking.IsShared).Count();
                totalBookingDetailNotShares += routeRoutine.BookingDetailDrivers.Where(bookingDetailDriver => !bookingDetailDriver.BookingDetail.Booking.IsShared).Count();

                var bookingDetailDriverOfRouteRoutineGroupings =
                    routeRoutine.BookingDetailDrivers
                    .GroupBy(e => e.BookingDetail.Date)
                    .OrderBy(g => g.Key)
                    .ToList();

                var totalSlots = routeRoutine.User.Vehicle.VehicleType.Slot;
                var routeStationDic = routeRoutine.Route.RouteStations
                    .ToDictionary(key => key.Id);

                foreach(var bookingDetailDriverGrouping in bookingDetailDriverOfRouteRoutineGroupings)
                {
                    var bookingDetailDrivers = bookingDetailDriverGrouping.OrderBy(e => e.BookingDetail.Booking.Time).ToList();

                    List<BookingDetailDriver> prevBookingDetailDrivers = new();
                    var curSlots = 0;
                    
                    foreach(var bookingDetailDriver in bookingDetailDrivers)
                    {
                        // check prev booking has arrived destination yet
                        List<int> removeIndexs = new();
                        for(int i = 0; i < prevBookingDetailDrivers.Count; i++)
                        {
                            var prevBookingDetailDriver = prevBookingDetailDrivers[i];

                            var prevEndRouteStation = routeStationDic[prevBookingDetailDriver.BookingDetail.Booking.EndRouteStationId];
                            var curStartRouteStation = routeStationDic[bookingDetailDriver.BookingDetail.Booking.StartRouteStationId];

                            if (prevEndRouteStation.DistanceFromFirstStationInRoute <= curStartRouteStation.DistanceFromFirstStationInRoute)
                            {
                                removeIndexs.Add(i);
                                
                            }
                        }

                        foreach(var index in removeIndexs)
                        {
                            prevBookingDetailDrivers.RemoveAt(index);
                            curSlots--;
                        }
                        //=================================================

                        curSlots++;
                        if (!prevBookingDetailDrivers.Any())
                        {
                            prevBookingDetailDrivers.Add(bookingDetailDriver);
                            continue;
                        }

                        var prevBookingDetailDriverGrouping = prevBookingDetailDrivers
                            .GroupBy(e => e.BookingDetail.Booking.IsShared)
                            .ToDictionary(e => e.Key);

                        if (bookingDetailDriver.BookingDetail.Booking.IsShared)
                        {
                            if (prevBookingDetailDriverGrouping.TryGetValue(false, out var prevBookingDetailDriverNotShares))
                                totalConflictSharingConditionCases++;
                                

                            if (prevBookingDetailDriverGrouping.TryGetValue(true, out var prevBookingDetailDriverShares))
                            {
                                if (curSlots >= totalSlots) 
                                    totalConflictSharingConditionCases++;
                                else
                                {

                                    //check valid time

                                    var curStartStation = routeStationDic[bookingDetailDriver.BookingDetail.Booking.StartRouteStationId];
                                    var curStartTime = bookingDetailDriver.BookingDetail.Booking.Time;
                                    var timeArriveCurStartStation = routeRoutine.StartTime.AddMinutes(curStartStation.DurationFromFirstStationInRoute / 60);

                                    if (timeArriveCurStartStation.ToTimeSpan(curStartTime).TotalMinutes <= Bookings.AllowedMappingTimeRange)
                                        totalBookingDetailShares++;
                                    else
                                        totalConflictSharingConditionCases++; 
                                }
                            }
                        }
                        else
                        {
                            if (prevBookingDetailDrivers.Any()) 
                                totalConflictSharingConditionCases++;
                        }
                        
                    }
                }
            }
            return new
            {
                TotalBookingDetails = totalBookingDetails,
                TotalBookingDetailDrivers = totalBookingDetailDrivers,
                TotalBookingDetailCanShares = totalBookingDetailCanShares,
                TotalBookingDetailShares = totalBookingDetailShares,
                TotalBookingDetailNotShares = totalBookingDetailNotShares,
                TotalConflictSharingConditionCases = totalConflictSharingConditionCases,
            };
        }

        public Task<bool> Update(RouteRoutine routeRoutine) => UnitOfWork.RouteRoutines.Update(routeRoutine);
        public Task<bool> ExistAnyRoutines()
        {
            return UnitOfWork.RouteRoutines.GetAllRouteRoutine().AnyAsync();
        }    
    }
}
