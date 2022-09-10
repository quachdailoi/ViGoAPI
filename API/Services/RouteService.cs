using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using Domain.Shares.Classes;

namespace API.Services
{
    public class RouteService : IRouteService
    {
        public Task<Response> CreateRoutes(List<RouteDTO> routes, Response successResponse, Response dupplicateResponse, Response errorResponse)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetSteps(Location startPoint, Location endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
