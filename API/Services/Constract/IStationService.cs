using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IStationService
    {
        Task<List<Station>> Create(List<Station> stations);
        Task<Response> Create(List<StationDTO> stations, int userId, Response successResponse, Response duplicateResponse, Response errorResponse);
        Task<Response> Get(string? startStationCode, Response successResponse);
        Task<List<Station>> GetByCode(List<Guid> stationCodes);
        Task<Tuple<Station?,Station?>> GetPairOfStation(Guid stationCode1, Guid stationCode2);
        bool CheckDuplicateStations(List<StationDTO> stations);
        Task<bool> ExistSeedData();
        Task<List<Tuple<Station, double, object?>>?> GetStationSteps(Station startStation, Station endStation);
        Task<Response> GetNearByStationsByCoordinates(CoordinatesDTO coordinates, Response success, Response failed);

        Task<List<StationDTO>> GetStationDTOsByCodes(List<Guid> stationCodes);

        Task<List<StationDTO>> GetStationDTOsByIds(List<int> stationIds);
        IQueryable<Station> GetStationByCode(Guid code);
        Task<Station?> GetStationByCodeAsync(Guid code);
        Task<Guid?> NotExistedRouteCode(List<Guid> stationCodes);
        bool CheckStationWasBooked(int stationId);
        Task<bool> UpdateStation(UpdateStationRequest request, Station station);
        Task<bool> DeleteStation(Station station);
        PagingViewModel<IQueryable<StationViewModel>>? GetStations(string searchValue, PagingRequest paging);
    }
}
