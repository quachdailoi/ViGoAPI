using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using API.Utils;
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
        private readonly IFareService _fareService;
        private readonly IVehicleTypeService _vehicleTypeService;
        private IStationService _stationService;

        public RouteService(IUnitOfWork unitOfWork, IMapper mapper, IFareService fareService, IVehicleTypeService vehicleTypeService, IStationService stationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fareService = fareService;
            _vehicleTypeService = vehicleTypeService;
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
            var routes = await _unitOfWork.Routes.List(route => route.Status == StatusTypes.Route.Active).MapTo<RouteViewModel>(_mapper).ToListAsync();

            foreach(var route in routes) route.ProcessStation();

            return successResponse.SetData(routes);
        }

        public Task<bool> ExistSeedData()
        {
            return _unitOfWork.Routes.List().AnyAsync();
        }


        public async Task<Response> GetRouteFeeByPairOfStation(StationWithScheduleDTO dto, Response invalidStationResponse, Response invalidVehicleTypeResponse, Response successResponse, Response notFoundResponse)
        {
            var pairOfStation = await _stationService.GetPairOfStation(dto.StartStationCode, dto.EndStationCode);

            var startStationId = pairOfStation.Item1?.Id;
            var endStationId = pairOfStation.Item2?.Id;

            if (!startStationId.HasValue || !endStationId.HasValue)
                return invalidStationResponse;

            dto.StartStationId = startStationId.Value;
            dto.EndStationId = endStationId.Value;

            VehicleType? vehicleType = await _vehicleTypeService.GetByCode(dto.VehicleTypeCode);

            if (vehicleType == null) return invalidVehicleTypeResponse;

            dto.VehicleTypeId = vehicleType.Id;

            var routeViewModels =
                await _unitOfWork.Routes
                .List(route =>
                    route.Status == StatusTypes.Route.Active &&
                    route.RouteStations.Select(routeStation => routeStation.StationId).Contains(dto.StartStationId) &&
                    route.RouteStations.Select(routeStation => routeStation.StationId).Contains(dto.EndStationId))
                .MapTo<BookerRouteViewModel>(_mapper)
                .ToListAsync();

            var removeRouteIdHashSet = new HashSet<int>();

            foreach (var routeViewModel in routeViewModels)
            {
                List<StationInRouteViewModel> stations = new();
                var stationDic = routeViewModel.Stations
                    .DistinctBy(e => e.Id)
                    .ToDictionary(e => e.Id);

                var routeStationDic = routeViewModel.RouteStations.ToDictionary(e => e.Id);

                var startStation = stationDic[dto.StartStationId];
                var endStation = stationDic[dto.EndStationId];

                var startRouteStation = routeViewModel.RouteStations.Find(routeStation => routeStation.StationId == dto.StartStationId);
                var endRouteStation = routeViewModel.RouteStations.Find(routeStation => routeStation.StationId == dto.EndStationId);

                var currentRouteStation = startRouteStation;
                while (true)
                {
                    stations.Add(stationDic[currentRouteStation.StationId]);

                    if (currentRouteStation.StationId == dto.EndStationId || 
                        !currentRouteStation.NextRouteStationId.HasValue) break;

                    currentRouteStation = routeStationDic[currentRouteStation.NextRouteStationId.Value];
                }

                if (stations.First().Id == dto.StartStationId && stations.Last().Id == dto.EndStationId)
                {
                    var distance = endRouteStation.DistanceFromFirstStationInRoute - startRouteStation.DistanceFromFirstStationInRoute;
                    var duration = endRouteStation.DurationFromFirstStationInRoute - startRouteStation.DurationFromFirstStationInRoute;

                    routeViewModel.Stations = stations;
                    routeViewModel.Distance = distance >= 0 ? distance : routeViewModel.Distance + distance;
                    routeViewModel.Duration = duration >= 0 ? duration : routeViewModel.Duration + duration;
                    routeViewModel.Fee = await _fareService.CaculateFeeByDistance(dto.VehicleTypeId, routeViewModel.Distance, dto.Time);
                }
                else removeRouteIdHashSet.Add(routeViewModel.Id);
            }

            routeViewModels = routeViewModels
                .Where(e => 
                    !removeRouteIdHashSet.Contains(e.Id))
                .OrderBy(e => e.Distance)
                .Take(3)
                .ToList();

            return successResponse.SetData(routeViewModels);
        }

        public async Task<Domain.Entities.Route> CreateRoute(Domain.Entities.Route route)
        {
            return await _unitOfWork.Routes.CreateRoute(route);
        }

        public Task<Domain.Entities.Route> GetRouteByCode(string code)
        {
            return _unitOfWork.Routes.GetRouteByCode(code);
        }
    }
}
