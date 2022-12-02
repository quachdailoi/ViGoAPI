using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.SettingConfigs;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace API.Services
{
    public class RapidApiService : BaseService, IRapidApiService
    {
        private readonly HttpClient _client;
        private readonly List<string> _apiKeys;

        public RapidApiService(IAppServices appServices) : base(appServices)
        {
            _client = new HttpClient();

            _apiKeys = new List<string>();

            var keyStrs = Configuration.Get(RapidApiSettings.ApiKeys);

            if (keyStrs == null) throw new Exception("Failed to use api from rapidapi flatform.");

            _apiKeys = keyStrs.Split(",").ToList();
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
            var baseAddress = Configuration.Get(RapidApiSettings.TrueWayMatrixService_Uri);

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
                        { "X-RapidAPI-Host", Configuration.Get(RapidApiSettings.TrueWayMatrixService_ApiHost) },
                    }
                };

                using (var response = await _client.SendAsync(request))
                {
                    if ((int)response.StatusCode != StatusCodes.Status200OK)
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

        public async Task<KeyValuePair<double, double>> CalculateDistanceAndDurationFrom2Station(Station station1, Station station2)
        {

            string originParam = $"{station1.Latitude},{station1.Longitude}";
            string destinationParam = $"{station2.Latitude},{station2.Longitude}";

            var bodyJson = await TrueWayMatrix_CalculateDrivingMatrix(originParam, destinationParam);

            var distance = (double)bodyJson.distances[0][0];
            var duration = (double)bodyJson.durations[0][0];

            return KeyValuePair.Create(distance, duration);
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
        private string GenerateNameOfRoute(List<StationDTO> stations)
        {
            var firstStation = stations.First();
            var lastStation = stations.Last();
            var lastName = lastStation.Name;
            if (firstStation.Id == lastStation.Id)
            {
                lastName = stations[stations.Count - 2].Name;
            }
            return $"{stations.First().Name} - {lastName}";
        }
        public async Task<Domain.Entities.Route?> CreateRouteByListOfStation(List<StationDTO> stations, int? userId = null, string? routeName = null)
        {
            var constructedRoute = await TrueWayDirection_FindDrivingRoute(stations);

            if (userId.HasValue) constructedRoute.UpdatedBy = userId.Value;

            if (!routeName.IsNullOrEmpty()) constructedRoute.Name = routeName;
            else
            {
                constructedRoute.Name = GenerateNameOfRoute(stations);
            }
            await UnitOfWork.CreateTransactionAsync();

            bool isSuccessTransaction = true;

            var createdRoute = await UnitOfWork.Routes.CreateRoute(constructedRoute);

            if (isSuccessTransaction = createdRoute != null)
            {
                //connect last station and first station in circle route
                if (stations.Last().Id == stations.First().Id)
                {
                    createdRoute.RouteStations.Last().NextRouteStationId = createdRoute.RouteStations.First().Id;
                    if (!await UnitOfWork.Routes.Update(createdRoute))
                    {
                        isSuccessTransaction = false;
                    }
                }
            }

            if (!isSuccessTransaction)
            {
                await UnitOfWork.Rollback();
                return null;
            }
            else await UnitOfWork.CommitAsync();

            return createdRoute;
        }

        public async Task<Response> CreateRoute(int adminId, CreateRouteRequest request, Response success, Response failed)
        {
            var stations = await AppServices.Station.GetStationDTOsByCodes(request.StationCodes);

            var createdRoute = await CreateRouteByListOfStation(stations, adminId, request.RouteName);
            if (createdRoute == null) return failed;
            var routeVM = 
                (await UnitOfWork.Routes.List()
                    .Where(x => x.Id == createdRoute.Id)
                    .MapTo<RouteViewModel>(Mapper, AppServices)
                    .FirstAsync()).ProcessStation();

            return success.SetData(routeVM);
        }

        public async Task<RouteViewModel?> UpdateRouteByListOfStation(Domain.Entities.Route route, List<StationDTO> stations)
        {
            //--- delete old routestation
            var deletedRouteStations = await UnitOfWork.RouteStations.DeleteRouteStations(route.RouteStations, softDelete: true);

            if (!deletedRouteStations)
            {
                return null;
            }
            //--- delete old routestation

            await TrueWayDirection_FindDrivingRoute(stations, route);

            var updatedResult = await UnitOfWork.Routes.UpdateRoute(route);

            if (!updatedResult) return null;

            var routeVM =
               (await UnitOfWork.Routes.List()
                   .Where(x => x.Id == route.Id)
                   .MapTo<RouteViewModel>(Mapper, AppServices)
                   .FirstOrDefaultAsync())?.ProcessStation();

            return routeVM;
        }

        public async Task<Domain.Entities.Route> TrueWayDirection_FindDrivingRoute(List<StationDTO> stations, Domain.Entities.Route? route = null)
        {
            var baseAddress = Configuration.Get(RapidApiSettings.TrueWayDirectionService_Uri);

            var stationCoorStrs = this.BuildCoordinateString(stations);

            var url = $"/FindDrivingRoute?stops={stationCoorStrs}";

           
            foreach (var key in _apiKeys)
            {

                if (route == null) route = new Domain.Entities.Route();

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseAddress + url),
                    Headers =
                    {
                        { "X-RapidAPI-Key", key },
                        { "X-RapidAPI-Host", Configuration.Get(RapidApiSettings.TrueWayDirectionService_ApiHost) },
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

                    route.RouteStations = GenerateRouteStation(stations, route, legs);
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

        private List<RouteStation> GenerateRouteStation(List<StationDTO> stations, Domain.Entities.Route route, dynamic legs)
        {
            List<RouteStation> routestations = new();

            double distance = 0;
            double duration = 0;

            var isCircleRoute = stations.First().Id == stations.Last().Id;
            var totalStation = isCircleRoute ? stations.Count - 1 : stations.Count; 

            for (var index = 0; index < totalStation; index++)
            {
                var station = stations[index];
                
                distance += (index > 0) ? (double)(legs[index - 1].distance) : 0;
                duration += (index > 0) ? (double)(legs[index - 1].duration) : 0;

                var routeStation = new RouteStation
                {
                    Route = route,
                    StationId = station.Id,
                    Index = index + 1,
                    DistanceFromFirstStationInRoute = distance,
                    DurationFromFirstStationInRoute = duration,
                };

                if (routestations.Any()) routestations.Last().NextRouteStation = routeStation;
                routestations.Add(routeStation);                           
            }

            return routestations;
        }
    }
}
