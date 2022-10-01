using API.Models.DTO;
using API.Models.Response;
using Domain.Shares.Classes;

namespace API.Services.Constract
{
    public interface IRapidApiService
    {
        Task<List<DistanceStationDTO>> CalculateDrivingMatrix(CoordinatesDTO origin, List<DistanceStationDTO> destinations);
        Task<Domain.Entities.Route?> CreateRouteByListOfStation(List<StationDTO> stations);
        Task<Response> CreateRoute(List<StationDTO> stations, Response success, Response failed);
    }
}
