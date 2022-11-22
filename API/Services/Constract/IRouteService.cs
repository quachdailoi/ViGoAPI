using Domain.Entities;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using API.Models.Requests;
using API.Models.Responses;

namespace API.Services.Constract
{
    public interface IRouteService
    {
        Task<List<Domain.Entities.Route>> Create(List<Domain.Entities.Route> routes);      
        Task<Response> CreateRange(List<RouteDTO> routes, Response successResponse, Response dupplicateResponse, Response errorResponse);
        Task<Response> GetAll(StartStationRequest request, Response successResponse);
        Task<bool> ExistSeedData();
        Task<Response> GetRouteFeeByPairOfStation(StationWithScheduleDTO dto, Response invalidStationResponse,Response invalidVehicleTypeResponse,Response successResponse, Response notFoundResponse);
        Task<Domain.Entities.Route> CreateRoute(Domain.Entities.Route route);
        Task<Domain.Entities.Route> GetRouteByCode(string code);
        Task<RouteViewModel?> UpdateRoute(Domain.Entities.Route route, List<StationDTO> stationDTOs);

        IQueryable<Domain.Entities.Route> GetRoute(string code);

        bool CheckRouteWasBooked(int routeId);
        Task<bool> DeleteRoute(Domain.Entities.Route route);
        PagingViewModel<IQueryable<RouteViewModel>>? GetRoutes(string searchValue, PagingRequest paging);
        IQueryable<RouteViewModel>? GetRoutes(string searchValue);
    }
}
