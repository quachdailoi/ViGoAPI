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
    public class RouteRoutineService : IRouteRoutineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RouteRoutineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool CheckValidRoutineForRoute(CreateRouteRoutineRequest request)
        {
            var driverRouteRoutineCurrent = _unitOfWork.RouteRoutines.GetActiveRoutines(request.UserId)
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

        public Task<List<RouteRoutine>> CreateRouteRoutines(List<RouteRoutine> routines) => _unitOfWork.RouteRoutines.Add(routines);

        public async Task<Response> CreateRouteRoutine(CreateRouteRoutineRequest request, Response success, Response failed)
        {
            var newRouteData = _mapper.Map<RouteRoutine>(request);

            var routeRoutineCreated = await _unitOfWork.RouteRoutines.Add(newRouteData);

            if (routeRoutineCreated == null) return failed;

            return success.SetData(_mapper.Map<RouteRoutineViewModel>(routeRoutineCreated));
        }

        public async Task<Response> GetRouteRoutineOfDriver(int driverId, Response success)
        {
            var routeRoutines =
                await _unitOfWork.RouteRoutines.GetAllRouteRoutine(driverId)
                    .MapTo<RouteRoutineViewModel>(_mapper)
                    .ToListAsync();

            return success.SetData(routeRoutines);
        }

        public Task<List<RouteRoutine>> GetByRouteId(int routeId) => 
            _unitOfWork.RouteRoutines
            .List(routeRoutine => 
                routeRoutine.RouteId == routeId && 
                routeRoutine.Status == RouteRoutines.Status.Active)
            .Include(e => e.User)
            .ThenInclude(u => u.Vehicle)
            .Include(e => e.User)
            .ThenInclude(u => u.BookingDetailDrivers)
            .ThenInclude(bdr => bdr.BookingDetail)
            .ThenInclude(bd => bd.Booking)
            .ToListAsync();

        public async Task<dynamic> GetMappedBookingDetailDriverByRouteRoutine()
        {
            var routeRoutines = await _unitOfWork.RouteRoutines
            .List(routeRoutine =>
                routeRoutine.Status == RouteRoutines.Status.Active)
            .Include(e => e.User)
            .ThenInclude(u => u.Vehicle)
            .ThenInclude(v => v.VehicleType)
            .Include(e => e.User)
            .ThenInclude(u => u.BookingDetailDrivers)
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

            totalBookingDetails = await _unitOfWork.BookingDetails.List(bookingDetail => bookingDetail.Status != BookingDetails.Status.Cancelled).CountAsync();

            foreach(var routeRoutine in routeRoutines)
            {
                var startDate = routeRoutine.StartAt;
                var endDate = routeRoutine.EndAt;
                var startTime = routeRoutine.StartTime;
                var endTime = routeRoutine.EndTime;

                var bookingDetailDriverOfRouteRoutines =
                    routeRoutine.User.BookingDetailDrivers.Where(bookingDetailDriver =>
                        bookingDetailDriver.BookingDetail.Status != BookingDetails.Status.Cancelled &&
                        bookingDetailDriver.BookingDetail.Date >= startDate &&
                        bookingDetailDriver.BookingDetail.Date <= endDate &&
                        bookingDetailDriver.BookingDetail.Booking.Time >= startTime &&
                        bookingDetailDriver.BookingDetail.Booking.Time <= endTime)
                    .ToList();

                totalBookingDetailDrivers += bookingDetailDriverOfRouteRoutines.Count;
                totalBookingDetailCanShares += bookingDetailDriverOfRouteRoutines.Where(bookingDetailDriver => bookingDetailDriver.BookingDetail.Booking.IsShared).Count();
                totalBookingDetailNotShares += bookingDetailDriverOfRouteRoutines.Where(bookingDetailDriver => !bookingDetailDriver.BookingDetail.Booking.IsShared).Count();

                var bookingDetailDriverOfRouteRoutineGroupings =
                    bookingDetailDriverOfRouteRoutines
                    .GroupBy(e => e.BookingDetail.Date)
                    .OrderBy(g => g.Key)
                    .ToList();

                var totalSlots = routeRoutine.User.Vehicle.VehicleType.Slot;
                var routeStationDic = routeRoutine.Route.RouteStations
                    .ToDictionary(key => key.Station.Code);

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
                            var prevBookingDetailDriverEndtime = prevBookingDetailDriver.BookingDetail.Booking.Time.AddMinutes(prevBookingDetailDriver.BookingDetail.Booking.Duration / 60);
                            if (prevBookingDetailDriverEndtime <= bookingDetailDriver.BookingDetail.Booking.Time)
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
                            {
                                foreach(var prevBookingDetailDriverNotShare in prevBookingDetailDriverNotShares)
                                {
                                    var _endTime = prevBookingDetailDriverNotShare.BookingDetail.Booking.Time.AddMinutes(prevBookingDetailDriverNotShare.BookingDetail.Booking.Duration / 60);
                                    Console.WriteLine($"endTime: {endTime} | {_endTime}");
                                }
                                totalConflictSharingConditionCases++;
                            }
                                

                            if (prevBookingDetailDriverGrouping.TryGetValue(true, out var prevBookingDetailDriverShares))
                            {
                                if (curSlots >= totalSlots) 
                                    totalConflictSharingConditionCases++;
                                else
                                {
                                    var prevBookingDetailDriver = prevBookingDetailDriverShares.ToList()[0];

                                    //check valid distance

                                    var curStartStation = routeStationDic[bookingDetailDriver.BookingDetail.Booking.StartStationCode];
                                    var curStartTime = bookingDetailDriver.BookingDetail.Booking.Time;
                                    

                                    var prevEndStation = routeStationDic[prevBookingDetailDriver.BookingDetail.Booking.EndStationCode];
                                    var prevEndTime = prevBookingDetailDriver.BookingDetail.Booking.Time.AddMinutes(prevBookingDetailDriver.BookingDetail.Booking.Duration / 60);

                                    var curArrivePrevEndStation = curStartTime.AddMinutes((prevEndStation.DurationFromFirstStationInRoute - curStartStation.DurationFromFirstStationInRoute) / 60);

                                    if (Math.Abs((curArrivePrevEndStation.ToTimeSpan() - prevEndTime.ToTimeSpan()).TotalMinutes) >1 ) 
                                        totalConflictSharingConditionCases++;
                                    else
                                    {
                                        totalBookingDetailShares++;
                                    }
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
