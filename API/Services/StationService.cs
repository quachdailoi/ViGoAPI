﻿using API.Models;
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
using FluentValidation;

namespace API.Services
{
    public class StationService : BaseService<StationService>, IStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRapidApiService _rapidApiService;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private readonly ILocationService _locationService;

        public StationService(
			ILogger<StationService> logger, 
			IUnitOfWork unitOfWork, 
			IMapper mapper,
			IRapidApiService rapidApiService,  
			IDistributedCache cache,
			ILocationService locationService) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _rapidApiService = rapidApiService;
            _mapper = mapper;
            _cache = cache;
			_locationService = locationService;
        }

        public async Task<Response> GetNearByStationsByCoordinates(CoordinatesDTO coordinates, Response success, Response failed)
        {
                var distanceStations = GetNearByStationsAsTheCrowFlies(coordinates);

                var sortedDistanceStations = await _rapidApiService.CalculateDrivingMatrix(coordinates, distanceStations);

                return success.SetData(sortedDistanceStations);
        }

        public List<DistanceStationDTO> GetNearByStationsAsTheCrowFlies(CoordinatesDTO coordinates)
        {
            var startStationCode = coordinates.StartStationCode;
            int? startStationId = null;
            if (startStationCode.HasValue)
            {
                var startStation = _unitOfWork.Stations.GetStationsByCodes(new() { startStationCode.Value }).FirstOrDefault();

                if (startStation != null)
                {
                    startStationId = startStation.Id;
                }
            }

            var stations = _unitOfWork.Stations.List();

            if (startStationId != null)
            {
                var routeIdsOfStartStation = 
                    _unitOfWork.RouteStations.List().Where(x => x.StationId == startStationId).Select(x => x.RouteId);

                if (routeIdsOfStartStation == null) throw new Exception("Start station does not belong to any routes.");

                var stationIdsInSameRouteOfStart = 
                    _unitOfWork.RouteStations.List().Where(x => x.StationId != startStationId && routeIdsOfStartStation.Contains(x.RouteId))
                    .GroupBy(x => x.StationId)    
                    .Select(x => x.Key);

                if (stationIdsInSameRouteOfStart == null) throw new Exception("Not found any station in the same routes with start station.");

                stations = stations.Where(x => stationIdsInSameRouteOfStart.Contains(x.Id));
            }

            var reasonableStations = stations.ToList()
                .Select(x => new DistanceStationDTO
                {
                    Station = new()
                    {
                        Code = x.Code,
                        Latitude = x.Latitude,
                        Longitude = x.Longitude,
                        Name = x.Name,
                        Address = x.Address,
                    },
                    Distance = ILocationService.CalculateDistanceAsTheCrowFlies(coordinates.Latitude, coordinates.Longitude, x.Latitude, x.Longitude),
                })
                .OrderBy(x => x.Distance)
                .Take(10);

            return reasonableStations.ToList();
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

        public async Task<Response> Get(string? startStationCode, Response successResponse)
        {
            var stations = _unitOfWork.Stations.List(station => station.Status == StatusTypes.Station.Active);

            if (startStationCode != null)
            {
                var startStation = _unitOfWork.Stations.GetStationByCode(startStationCode).FirstOrDefault();
                if (startStation == null) throw new ValidationException("Not found start station with this code.");
                stations = stations.Where(station => station.Code.ToString() != startStationCode && station.RouteStations.Where(rs => rs.Route.RouteStations.Where(rs => rs.StationId == startStation.Id).Any()).Any());
            }

            return successResponse.SetData(await stations.MapTo<StationViewModel>(_mapper).ToListAsync());
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

        public async Task<List<StationDTO>> GetStationDTOsByCodes(List<Guid> stationCodes)
        {
            var stationDtoDic = (await _unitOfWork.Stations
                .GetStationsByCodes(stationCodes)
                .MapTo<StationDTO>(_mapper)
                .ToListAsync())
                .ToDictionary(e => e.Code);

            List<StationDTO> stationDtos = new();
            foreach (var code in stationCodes)
            {
                stationDtos.Add(stationDtoDic[code]);
            }

            return stationDtos;
        }

        public async Task<List<StationDTO>> GetStationDTOsByIds(List<int> stationIds)
        {
            var stationDtoDic = (await _unitOfWork.Stations
                .GetStationsByIds(stationIds)
                .MapTo<StationDTO>(_mapper)
                .ToListAsync())
                .ToDictionary(e => e.Id);

            List <StationDTO> stationDtos = new();
            foreach (var id in stationIds)
            {
                stationDtos.Add(stationDtoDic[id]);
            }

            return stationDtos;
        }
    }
}

