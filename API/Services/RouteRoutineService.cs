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
    }
}
