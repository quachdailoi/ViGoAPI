using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
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

            var NewStartAt = DateTimeExtensions.ParseExactDateOnly(request.StartAt);
            var NewEndAt = DateTimeExtensions.ParseExactDateOnly(request.EndAt);
            var NewStartTime = DateTimeExtensions.ParseExactTimeOnly(request.StartTime);
            var NewEndTime = NewStartTime.AddMinutes(request.Route.Duration / 60);

            request.StartAtParsed = NewStartAt;
            request.EndAtParsed = NewEndAt;
            request.StartTimeParsed = NewStartTime;
            request.EndTimeParsed = NewEndTime;

            if (driverRouteRoutineCurrent == null || !driverRouteRoutineCurrent.Any()) return true;

            return !driverRouteRoutineCurrent.ToList()
                .Where(x => (NewStartAt <= x.EndAt && NewEndAt >= x.StartAt && NewStartTime < x.EndTime.RoundUp(30) && NewEndTime.RoundUp(30) > x.StartTime))
                .Any();
        }

        public Task<List<RouteRoutine>> CreateRouteRoutines(List<RouteRoutine> routines) => UnitOfWork.RouteRoutines.Add(routines);

        public async Task<Response> CreateRouteRoutine(CreateRouteRoutineRequest request, Response success, Response failed)
        {
            var newRouteRoutineData = new RouteRoutine()
            {
                RouteId = request.Route.Id,
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
            return success.SetData(viewModel);
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
    }
}
