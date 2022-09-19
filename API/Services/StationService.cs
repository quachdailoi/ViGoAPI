using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Extensions;
using API.Helpers;
using API.Services.Constract;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Shares.Enums;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace API.Services
{
    public class StationService : BaseService<StationService>, IStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrueWayMatrixApiService _trueWayMatrixApiService;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private readonly ILocationService _locationService;

        public StationService(
			ILogger<StationService> logger, 
			IUnitOfWork unitOfWork, 
			IMapper mapper,
			ITrueWayMatrixApiService trueWayMatrixApiService,  
			IDistributedCache cache,
			ILocationService locationService) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _trueWayMatrixApiService = trueWayMatrixApiService;
            _mapper = mapper;
            _cache = cache;
			_locationService = locationService;
        }

        public async Task<Response> GetNearByStationsByCoordinates(CoordinatesDTO coordinates, Response success, Response failed)
        {

                var distanceStations = GetNearByStationsBy2DFormula(coordinates);

                var sortedDistanceStations = await _trueWayMatrixApiService.CalculateDrivingMatrix(coordinates, distanceStations);

                return success.SetData(sortedDistanceStations);
        }

        public List<DistanceStationDTO> GetNearByStationsBy2DFormula(CoordinatesDTO coordinates)
        {
            var stations = _unitOfWork.Stations.List()
                .ToList()
                .Select(x => new DistanceStationDTO
                {
                    Station = new()
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

        public Task<List<Station>> Create(List<Station> stations)
        {
            return _unitOfWork.Stations.Add(stations);
        }
        public bool CheckDuplicateStations(List<StationDTO> stations)
        {
            return stations.DistinctBy(station => $"{station.Latitude}|{station.Longitude}").Any();
        }
        private Task<bool> CheckDulpicateStationsWithinDatabase(List<StationDTO> stations)
        {
            return _unitOfWork.Stations.List(station => stations.Exists(_station => _station.Latitude == station.Latitude &&
                                                                                               _station.Longitude == station.Longitude) &&
                                                                               station.Status == StatusTypes.Station.Active)
                                                              .AnyAsync();
        }
        public async Task<Response> Create(List<StationDTO> stations, int userId, Response successResponse, Response duplicateResponse, Response errorResponse)
        {

            if (!(await CheckDulpicateStationsWithinDatabase(stations))) return duplicateResponse;

            foreach (var station in stations)
            {
                station.CreatedBy = userId;
                station.UpdatedBy = userId;
            };

            var stationEntities = _mapper.Map<List<Station>>(stations);

            stationEntities = await _unitOfWork.Stations.Add(stationEntities);

            if (stationEntities == null) return errorResponse;

            return successResponse.SetData(_mapper.Map<List<StationViewModel>>(stationEntities));

        }

        public Task<bool> ExistSeedData()
        {
            return _unitOfWork.Stations.List().AnyAsync();
        }

        public async Task<Response> Get(Response successResponse)
        {
            var stations = await _unitOfWork.Stations.List(station => station.Status == StatusTypes.Station.Active).MapTo<StationViewModel>(_mapper).ToListAsync();

            return successResponse.SetData(stations);
        }

        public async Task<List<Tuple<Station, double, object?>>?> GetStationSteps(Station startStation, Station endStation)
        {
            var serializableGraph = await _cache.GetStringAsync("graph");

            Graph<Station> graph;

            if (serializableGraph == null)
            {
                var routeStations =
                    await _unitOfWork.RouteStations
                        .List(routeStation =>
                                routeStation.Status == StatusTypes.RouteStation.Active &&
                                routeStation.Station.Status == StatusTypes.Station.Active &&
                                routeStation.Route.Status == StatusTypes.Route.Active)
                        .ToListAsync();

                graph = Mapping.InitialGraph(routeStations);

                await _cache.SetStringAsync("graph", JsonConvert.SerializeObject(graph));
            }
            else
            {
                graph = JsonConvert.DeserializeObject<Graph<Station>>(serializableGraph);
            }

            if (!graph.Contains(startStation)) AddStationToGraph(startStation, graph);

            if (!graph.Contains(endStation)) AddStationToGraph(endStation, graph);

            return graph.GetShortestPath(startStation, endStation, 2);

        }

        private void AddStationToGraph(Station station, in Graph<Station> graph)
        {
            graph.Add(station);

            var routeStations = station.RouteStations
                .Where(routeStation =>
                            routeStation.Status == StatusTypes.RouteStation.Active &&
                            routeStation.Station.Status == StatusTypes.Station.Active &&
                            routeStation.Route.Status == StatusTypes.Route.Active)
                .GroupBy(routeStation => routeStation.RouteId)
                .First()
                .OrderBy(routeStation => routeStation.Index)
                .ToList();

            var startStationInRoute = routeStations.ElementAt(0).Station;
            var endStationInRoute = routeStations.Last().Station;

            var startStationInRouteStation = routeStations.Find(routeStation => routeStation.StationId == station.Id);

            graph.AddEdge(startStationInRoute, station, startStationInRouteStation.DistanceFromFirstStationInRoute);
            graph.AddEdge(station, endStationInRoute, startStationInRouteStation.DistanceFromFirstStationInRoute);
        }

        public Task<List<Station>> GetByCode(List<Guid> stationCodes)
        {
            return
                _unitOfWork.Stations
                .List(station =>
                    stationCodes.Contains(station.Code) &&
                    station.Status == StatusTypes.Station.Active)
                .Include(station => station.RouteStations)
                .ThenInclude(routeStation => routeStation.Route)
                .ToListAsync();
        }
    }
}

