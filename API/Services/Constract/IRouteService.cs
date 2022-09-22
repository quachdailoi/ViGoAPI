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
        Task<bool> IsExistData();
        Task<Response> GetRouteFeeByPairOfStation(StationWithScheduleDTO dto, Response successResponse, Response notFoundResponse);
        Task<Response> GetRoutesByPairsOfStation(List<int> startStationIds, List<int> endStationIds, Response successResposne);
        Task<List<RouteViewModel>> GetRouteByListOfStations(Station startStation, List<Tuple<Station, double, object>> stepStations);
        Task<Response> GetRouteByPairOfStation(int startStationId, int endStationId, VehicleTypes vehicleType, Response successResponse, Response notFoundResponse);
        Task<Response> GetStepsByPairOfStations(Station startStation, Station endStation, VehicleTypes vehicleType, Response successResponse);

        Task<Domain.Entities.Route> CreateRoute(Domain.Entities.Route route);
    }
}
