using Domain.Entities;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IRouteService
    {
        Task<List<Domain.Entities.Route>> Create(List<Domain.Entities.Route> routes);      
        Task<Response> CreateRange(List<RouteDTO> routes, Response successResponse, Response dupplicateResponse, Response errorResponse);
        Task<Response> GetAll(Response successResponse);
        Task<bool> ExistSeedData();
        Task<Response> GetRouteFeeByPairOfStation(StationWithScheduleDTO dto, Response invalidStationResponse,Response invalidVehicleTypeResponse,Response successResponse, Response notFoundResponse);
        Task<Domain.Entities.Route> CreateRoute(Domain.Entities.Route route);
        Task<Domain.Entities.Route> GetRouteByCode(string code);
    }
}
