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

        public StationService(ILogger<StationService> logger, IUnitOfWork unitOfWork, ITrueWayMatrixApiService trueWayMatrixApiService) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _trueWayMatrixApiService = trueWayMatrixApiService;
        }

        public async Task<Response> GetNearByStationsByCoordinates(CoordinatesDTO coordinates, Response success, Response failed)
        {
            try
            {
                var distanceStations = GetNearByStationsBy2DFormula(coordinates);

                var sortedDistanceStations = await _trueWayMatrixApiService.CalculateDrivingMatrix(coordinates, distanceStations);

                return success.SetData(sortedDistanceStations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return failed;
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
                    Distance = CalculateDistanceBy2DFormula(coordinates.Latitude, coordinates.Longitude, x.Latitude, x.Longitude),
                })
                .OrderBy(x => x.Distance)
                .Take(25);

            return stations.ToList();
        }

        private static double CalculateDistanceBy2DFormula(double lat1, double long1, double lat2, double long2)
        {
            var phi1 = lat1 * Math.PI / 180;
            var phi2 = lat2 * Math.PI / 180;

            var delta_phi = (lat2 - lat1) * Math.PI / 180;
            var delta_lambda = (long2 - long1) * Math.PI / 180;

            var a = Math.Sin(delta_phi / 2) * Math.Sin(delta_phi / 2) +
                Math.Cos(phi1) * Math.Cos(phi2) * Math.Sin(delta_lambda / 2) * Math.Sin(delta_lambda / 2);

            double R = 6371e3; // earthRadius

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = R * c;

            return distance;
        }
    }
}
