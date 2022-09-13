using API.Models.DTO;
using API.Models.Response;
using Domain.Shares.Classes;

namespace API.Services.Constract
{
    public interface IRouteService
    {
        Task<Response> GetSteps(Location startPoint, Location endPoint);
        Task<Response> CreateRoutes(List<RouteDTO> routes, Response successResponse, Response dupplicateResponse, Response errorResponse);
    }
}
