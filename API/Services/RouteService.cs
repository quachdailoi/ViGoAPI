using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Services
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStationService _stationService;

        public RouteService(IUnitOfWork unitOfWork, IMapper mapper, IStationService stationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _stationService = stationService;
        }

        public Task<List<Domain.Entities.Route>> Create(List<Domain.Entities.Route> routes)
        {
            return _unitOfWork.Routes.Add(routes);
        }

        public async Task<Response> CreateRange(List<RouteDTO> routes, Response successResponse, Response dupplicateResponse, Response errorResponse)
        {
            var routeEntities = _mapper.Map<List<Domain.Entities.Route>>(routes);

            //check duplicate

            routeEntities = await Create(routeEntities);

            if(routeEntities == null) return errorResponse;

            return successResponse.SetData(routeEntities);
        }

        public async Task<Response> GetAll(Response successResponse)
        {
            //var _routes = await _unitOfWork.Routes.List(route => route.Status == StatusTypes.Route.Active).ToListAsync();
            var routes = await _unitOfWork.Routes.List(route => route.Status == StatusTypes.Route.Active).MapTo<RouteViewModel>(_mapper).ToListAsync();

            return successResponse.SetData(routes);
        }

        public Task<Response> GetSteps(Location startPoint, Location endPoint)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistData()
        {
            return _unitOfWork.Routes.List().AnyAsync();
        }

        public async Task<List<RouteViewModel>> GetRouteByListOfStations(Station startStation, List<Tuple<Station,double,object>> stepStations)
        {
            var routeIds = stepStations.Select(stepStation => stepStation.Item3).Cast<int>();

            var routes =
                (await _unitOfWork.Routes
                    .List(route => routeIds.Contains(route.Id))
                    .ToListAsync())
                .ToDictionary<Domain.Entities.Route, int>(e => e.Id);

            //var stationIds = stationsWithDistance.Keys.Select(station => station.Id).Append(startStation.Id);
            //var routes = 
            //    await _unitOfWork.Routes
            //        .List(route => 
            //            route.RouteStations
            //            .Select(routeStation => routeStation.StationId)
            //            .Intersect(stationIds)
            //            .Any())
            //        .Include(route => route.RouteStations)
            //        .ToListAsync();

            //RouteViewModel routeViewModel = new();
            //routeViewModel.Stations.Add(_mapper.Map<StationInRouteViewModel>(stations[0]));

            //for (int i = 0; i < stations.Count -1 ; i++)
            //{
            //    var routeContainStations = routes.Where(_route => 
            //                        _route.RouteStations
            //                        .Select(_routeStation => _routeStation.StationId)
            //                        .Intersect(new List<int> { stations[i].Id, stations[i+1].Id })
            //                        .Count() == 2)
            //                      .ToList();

            //    //=================== stuck here ===========================


            //    routeViewModel.Stations.Add(_mapper.Map<StationInRouteViewModel>(stations[i+1]));
            //}

            List<RouteViewModel> routeViewModels = new();

            Tuple<Station, double, object> prevStepStation = null;

            foreach (var stepStation in stepStations)
            {
                var station = stepStation.Item1;
                var distanceFromStartStation = stepStation.Item2;
                var routeId = (int)stepStation.Item3;

                var route = routes[routeId];

                var routeViewModel = _mapper.Map<RouteViewModel>(route);

                var prevStationViewModel = _mapper.Map<StationInRouteViewModel>(prevStepStation == null ? startStation : prevStepStation.Item1);

                var currentStationViewModel = _mapper.Map<StationInRouteViewModel>(station);

                routeViewModel.Stations.AddRange(new List<StationInRouteViewModel> { prevStationViewModel, currentStationViewModel });

                List<Step> steps = new();

                double totalDistance = 0;
                double totalDuration = 0;

                foreach (var step in route.Steps)
                {
                    if (step.StationId != station.Id)
                    {
                        steps.Add(step);

                        totalDistance += step.Distance;
                        totalDuration += step.Duration;

                        route.Steps.Remove(step);
                    }
                    else break;
                };

                routeViewModel.Steps = steps;
                routeViewModel.Distance = totalDistance;
                routeViewModel.Duration = totalDuration;

                if (routeViewModels.Any() && routeViewModels.Last().Id == routeId)
                {
                    routeViewModels.Last().Stations.Add(currentStationViewModel);

                    routeViewModels.Last().Steps.Concat(steps);

                    routeViewModels.Last().Distance += totalDistance;

                    routeViewModels.Last().Duration += totalDuration;
                }
                else
                {
                    routeViewModels.Add(routeViewModel);
                }

                prevStepStation = stepStation;
            }
               
            return routeViewModels;
        }

        public async Task<Response> GetRouteByPairOfStation(int startStationId, int endStationId, Response successResponse)
        {
            var route =
               await _unitOfWork.Routes
               .List(
                       route => route.RouteStations
                           .Select(routeStation => routeStation.StationId)
                           .Intersect(new List<int> { startStationId, endStationId })
                           .Count() == 2)
               .MapTo<RouteViewModel>(_mapper)
               .FirstOrDefaultAsync();

            List<Step> steps = new();

            double totalDistance = 0;

            double totalDuration = 0;

            for(var index = 0; index < route.Steps.Count; index++)
            {
                var step = route.Steps[index];
                var stationId = step.StationId;

                if (!stationId.HasValue || stationId.Value != endStationId)
                {
                    steps.Add(step);
                    totalDistance += step.Distance;
                    totalDuration += step.Duration;
                }
                else break;
            }

            route.Steps = steps;
            route.Distance = totalDistance;
            route.Duration = totalDuration;

            var fee = totalDistance / 1000 * 12000;

            return successResponse.SetData(new
            {
                Route = route,
                Fee = fee
            });
        }

        public async Task<Response> GetStepsByPairOfStations(Station startStation, Station endStation, VehicleTypes vehicleType, Response successResposne)
        {
            var stepStations = await _stationService.GetStationSteps(startStation, endStation);



            var routes = await this.GetRouteByListOfStations(startStation,stepStations);

            var totalDistance = routes.Select(route => route.Distance).Aggregate((current, next) => current + next);

            // caculate fee

            var fee = totalDistance / 1000 * 12000;

            return successResposne.SetData(new
            {
                Path = routes,
                Fee = fee
            });
        }

        public Task<Response> GetRoutesByPairOfStation(Station startStation, Station endStation, Response successResponse)
        {
            throw new NotImplementedException();
        }
    }
}
