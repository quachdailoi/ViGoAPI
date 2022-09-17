using API.Models.DTO;
using Domain.Shares.Classes;

namespace API.Services.Constract
{
    public interface ITrueWayMatrixApiService
    {
        Task<List<DistanceStationDTO>> CalculateDrivingMatrix(CoordinatesDTO origin, List<DistanceStationDTO> destinations);
    }
}
