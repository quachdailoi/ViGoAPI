using API.Models.Requests;
using API.Models.Response;

namespace API.Services.Constract
{
    public interface IRouteRoutineService
    {
        bool CheckValidRoutineForRoute(CreateRouteRoutineRequest request);

        Task<Response> CreateRouteRoutine(CreateRouteRoutineRequest request, Response success, Response failed);

        Task<Response> GetRouteRoutineOfDriver(int driverId, Response success);
    }
}
