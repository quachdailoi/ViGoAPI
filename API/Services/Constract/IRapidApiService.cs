using API.Models;
using API.Models.DTO;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Classes;

namespace API.Services.Constract
{
    public interface IRapidApiService
    {
        Task<List<DistanceStationDTO>> CalculateDrivingMatrix(CoordinatesDTO origin, List<DistanceStationDTO> destinations);
        Task<Domain.Entities.Route?> CreateRouteByListOfStation(List<StationDTO> stations, int? userId = null);
        Task<Response> CreateRoute(int adminId, List<StationDTO> stations, Response success, Response failed);
        Task<RouteViewModel?> UpdateRouteByListOfStation(Domain.Entities.Route route, List<StationDTO> stations);
        Task<KeyValuePair<double, double>> CalculateDistanceAndDurationFrom2Station(Station station1, Station station2);
    }
}
