using API.Models;
using API.Models.DTO;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Classes;

namespace API.Services.Constract
{
    public interface IRouteService
    {
        Task<List<Domain.Entities.Route>> Create(List<Domain.Entities.Route> routes);
        Task<RouteViewModel> GetSteps(Station station, Location endPoint);
        Task<Response> GetSteps(Location startPoint, Location endPoint);
        Task<Response> CreateRange(List<RouteDTO> routes, Response successResponse, Response dupplicateResponse, Response errorResponse);
        Task<Response> GetAll(Response successResponse);
        Task<bool> IsExistData();
    }
}
