using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Models.Settings;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Classes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace API.Services
{
    public class RapidApiService : IRapidApiService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly ILocationService _locationService;
        private readonly HttpClient _client;
        private readonly List<string> _apiKeys;

        public RapidApiService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration, ILocationService locationService)
        {
            _client = new HttpClient();
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = configuration;
            _locationService = locationService;

            _apiKeys = new List<string>();

            var keyStrs = _config.Get(RapidApiSettings.ApiKeys);

            if (keyStrs == null) throw new Exception("Failed to use api from rapidapi flatform.");

            _apiKeys = keyStrs.Split(",").ToList();
            Console.WriteLine($"Total rapid api keys: {_apiKeys.Count}");
        }

        public async Task<List<DistanceStationDTO>> CalculateDrivingMatrix(CoordinatesDTO origin, List<DistanceStationDTO> destinations)
        {
            string originsParam = $"{origin.Latitude},{origin.Longitude}";

            var destinationsParam = this.BuildCoordinateString(destinations);

            var bodyJson = await TrueWayMatrix_CalculateDrivingMatrix(originsParam, destinationsParam);

            LoadRealDistanceAndTime(ref destinations, bodyJson.distances[0], bodyJson.durations[0]);

            destinations.Sort();

            return destinations;
        }

        private async Task<dynamic> TrueWayMatrix_CalculateDrivingMatrix(string origins, string destinations)
        {
            var baseAddress = _config.Get(RapidApiSettings.TrueWayMatrixService_Uri);

            var url = $"/CalculateDrivingMatrix?origins={origins}&destinations={destinations}";

            foreach(var key in _apiKeys)
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseAddress + url),
                    Headers =
                    {
                        { "X-RapidAPI-Key", key },
                        { "X-RapidAPI-Host", _config.Get(RapidApiSettings.TrueWayMatrixService_ApiHost) },
                    }
                };

                using (var response = await _client.SendAsync(request))
                {
                    if ((int)response.StatusCode == StatusCodes.Status429TooManyRequests)
                    {
                        continue;
                    }
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    dynamic bodyJson = JToken.Parse(body);

                    return bodyJson;
                }
            }

            throw new Exception("Failed on all rapid api keys.");
        }

        private static List<DistanceStationDTO> LoadRealDistanceAndTime(ref List<DistanceStationDTO> stations, dynamic? distances, dynamic? durations)
        {
            for (var index = 0; index < stations.Count; index++)
            {
                stations[index].Distance = (double)distances[index];
                stations[index].Time = (double)durations[index];
            }

            return stations;
        }

        private string BuildCoordinateString(List<DistanceStationDTO> list)
        {
            var coorStrs = new List<string>();

            foreach (var point in list)
            {
                coorStrs.Add($"{point.Station.Latitude},{point.Station.Longitude}");
            }

            return string.Join(";", coorStrs.ToArray());
        }

        private string BuildCoordinateString(List<StationDTO> list)
        {
            var param = new List<DistanceStationDTO>();

            foreach (var station in list)
            {
                param.Add(new()
                {
                    Station = new()
                    {
                        Latitude = station.Latitude,
                        Longitude = station.Longitude,
                        Address = station.Address,
                        Name = station.Name
                    }
                });
            }

            return this.BuildCoordinateString(param);
        }

        public async Task<Response> CreateRoute(List<StationDTO> stations, Response success, Response failed)
        {
            var constructedRoute = await TrueWayDirection_FindDrivingRoute(stations);

            var createdRoute = await _unitOfWork.Routes.CreateRoute(constructedRoute);

            if (createdRoute == null)
            {
                return failed;
            }

            var routeVM = 
                (await _unitOfWork.Routes.List()
                    .Where(x => x.Id == createdRoute.Id)
                    .MapTo<RouteViewModel>(_mapper)
                    .ToListAsync()).FirstOrDefault();

            return success.SetData(routeVM);
        }

        public async Task<Domain.Entities.Route> TrueWayDirection_FindDrivingRoute(List<StationDTO> stations)
        {
            var baseAddress = _config.Get(RapidApiSettings.TrueWayDirectionService_Uri);

            var stationCoorStrs = this.BuildCoordinateString(stations);

            var url = $"/FindDrivingRoute?stops={stationCoorStrs}";

            var route = new Domain.Entities.Route();

            foreach (var key in _apiKeys)
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseAddress + url),
                    Headers =
                    {
                        { "X-RapidAPI-Key", key },
                        { "X-RapidAPI-Host", _config.Get(RapidApiSettings.TrueWayDirectionService_ApiHost) },
                    }
                };

                using (var response = await _client.SendAsync(request))
                {
                    if ((int)response.StatusCode == StatusCodes.Status429TooManyRequests)
                    {
                        continue;
                    }
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    dynamic bodyJson = JToken.Parse(body);

                    var distance = bodyJson.route.distance;
                    route.Distance = distance;

                    var duration = bodyJson.route.duration;
                    route.Duration = duration;

                    var bounds = bodyJson.route.bounds;
                    route.Bound.South = bounds.south;
                    route.Bound.West = bounds.west;
                    route.Bound.North = bounds.north;
                    route.Bound.East = bounds.east;

                    var legs = bodyJson.route.legs;

                    var stepsJson = GetStepsJson(stations, legs);

                    var steps = ConvertStepsJsonToSteps(stepsJson);

                    route.Steps = steps;

                    route.RouteStations = await GenerateRouteStation(stations, route, stationCoorStrs);
                }

                return route;
            }

            throw new Exception("Failed on all api keys.");
        }

        private static List<dynamic?> GetStepsJson(List<StationDTO> stations, dynamic? legs)
        {
            List<dynamic?> steps = new();

            for (var index = 0; index < legs.Count; index++)
            {
                var stepWithStation = legs[index].steps[0];

                stepWithStation.start_point.lat = stations[index].Latitude;
                stepWithStation.start_point.lng = stations[index].Longitude;
                stepWithStation.start_point.location_name = stations[index].Name;
                stepWithStation.station_id = stations[index].Id;

                steps.Add(stepWithStation);

                for (var j = 1; j < legs[index].steps.Count; j++)
                {
                    steps.Add(legs[index].steps[j]);
                }
            }

            return steps;
        }

        private List<Step> ConvertStepsJsonToSteps(List<dynamic> stepsJson) 
        {
            List<Step> steps = new();

            foreach (var stepJson in stepsJson)
            {
                var step = new Step()
                {
                    Distance = stepJson.distance,
                    Duration = stepJson.duration,
                    StartPoint = new()
                    {
                        Latitude = stepJson.start_point.lat,
                        Longitude = stepJson.start_point.lng,
                        LocationName = stepJson.start_point.location_name,
                    },
                    EndPoint = new()
                    {
                        Latitude = stepJson.end_point.lat,
                        Longitude = stepJson.end_point.lng,
                    },
                    Maneuver = stepJson.maneuver,
                    Bound = new()
                    {
                        South = stepJson.bounds.south,
                        West = stepJson.bounds.west,
                        North = stepJson.bounds.north,
                        East = stepJson.bounds.east,
                    }
                };

                if (stepJson.start_point.location_name != null)
                {
                    step.StationId = stepJson.station_id;
                }

                steps.Add(step);
            }
            
            return steps;
        }

        private async Task<List<RouteStation>> GenerateRouteStation(List<StationDTO> stations, Domain.Entities.Route route, string stationCoorStrs)
        {
            var firstStation = stations.First();
            List<RouteStation> routestations = new();

            string firstStationCoorStr = $"{stations.First().Latitude},{stations.First().Longitude}";

            var distanceAndTimeJson = await TrueWayMatrix_CalculateDrivingMatrix(firstStationCoorStr, stationCoorStrs);

            var distances = distanceAndTimeJson.distances[0];
            var durations = distanceAndTimeJson.durations[0];

            for (var index = 0; index < stations.Count; index++)
            {
                routestations.Add(new()
                {
                    Route = route,
                    StationId = stations[index].Id,
                    Index = index + 1,
                    DistanceFromFirstStationInRoute = distances[index],
                });
            }

            return routestations;
        }
    }
}
