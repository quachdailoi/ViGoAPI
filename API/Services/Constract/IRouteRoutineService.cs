using API.Models;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IRouteRoutineService
    {
        bool CheckValidRoutineForRoute(CreateRouteRoutineRequest request);

        Task<Response> CreateRouteRoutine(CreateRouteRoutineRequest request, Response success, Response failed);

        Task<Response> GetRouteRoutineOfDriver(int driverId, Response success);
        Task<List<RouteRoutine>> CreateRouteRoutines(List<RouteRoutine> routines);
        Task<List<RouteRoutine>> GetByRouteId(int routeId);
        Task<dynamic> GetMappedBookingDetailDriverByRouteRoutine();
        Task<List<RouteRoutine>> GetRouteRoutineFitBookingCondition(Booking booking);
        Task<bool> Update(RouteRoutine routeRoutine);
        Task<bool> ExistAnyRoutines();
        Task<InvalidRoutineViewModel?> CheckValidDistanceNewRoutine(CreateRouteRoutineRequest request);
        Task<Response?> CheckTimeToCreateRoutine(CreateRouteRoutineRequest request);
        Task<Response?> CheckDateToCreateRoutine(CreateRouteRoutineRequest request);
    }
}
