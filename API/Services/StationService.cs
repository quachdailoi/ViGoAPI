using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class StationService : BaseService<StationService>, IStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrueWayMatrixApiService _trueWayMatrixApiService;
        private readonly ILocationService _locationService;

        public StationService(ILogger<StationService> logger, 
            IUnitOfWork unitOfWork, 
            ITrueWayMatrixApiService trueWayMatrixApiService,
            ILocationService locationService) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _trueWayMatrixApiService = trueWayMatrixApiService;
            _locationService = locationService;
        }

        public async Task<Response> GetNearByStationsByCoordinates(CoordinatesDTO coordinates, Response success, Response failed)
        {
            
            {
                var distanceStations = GetNearByStationsBy2DFormula(coordinates);

                var sortedDistanceStations = await _trueWayMatrixApiService.CalculateDrivingMatrix(coordinates, distanceStations);

                return success.SetData(sortedDistanceStations);
            }
            
        }

        public List<DistanceStationDTO> GetNearByStationsBy2DFormula(CoordinatesDTO coordinates)
        {
            var stations = _unitOfWork.Station.List()
                .ToList()
                .Select(x => new DistanceStationDTO
                {
                    Station = new ()
                    {
                        Code = x.Code,
                        Latitude = x.Latitude,
                        Longitude = x.Longitude,
                        Name = x.Name
                    },
                    Distance = ILocationService.CalculateDistanceAsTheCrowFlies(coordinates.Latitude, coordinates.Longitude, x.Latitude, x.Longitude),
                })
                .OrderBy(x => x.Distance)
                .Take(25);

            return stations.ToList();
        }
    }
}
