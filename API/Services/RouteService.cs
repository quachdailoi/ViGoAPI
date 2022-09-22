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
            var routes = await _unitOfWork.Routes.List(route => route.Status == StatusTypes.Route.Active).MapTo<RouteViewModel>(_mapper).ToListAsync();

            return successResponse.SetData(routes);
        }

        public Task<bool> IsExistData()
        {
            return _unitOfWork.Routes.List().AnyAsync();
        }


        public async Task<Response> GetRouteFeeByPairOfStation(StationWithScheduleDTO dto, Response successResponse, Response notFoundResponse)
        {
            var routeStations =
                _unitOfWork.RouteStations
                .List(routeStation =>
                    routeStation.Status == StatusTypes.RouteStation.Active)
                .Where(routeStation =>
                    routeStation.StationId == dto.StartStationId ||
                    routeStation.StationId == dto.EndStationId);

            var startRouteStations =
                routeStations
                .Where(routeStation => routeStation.StationId == dto.StartStationId);

            var endRouteStations =
                routeStations
                .Where(routeStation => routeStation.StationId == dto.EndStationId);

            var routes =
                _unitOfWork.Routes
                .List(route =>
                    route.Status == StatusTypes.Route.Active &&
                    route.RouteStations.Select(routeStation => routeStation.StationId).Contains(dto.StartStationId) &&
                    route.RouteStations.Select(routeStation => routeStation.StationId).Contains(dto.EndStationId));

            // Get list of route satisfied start station and end station that order by distance from start station to end station in route
            var query =
              await (from _route in routes
                     join startStation in startRouteStations on _route.Id equals startStation.RouteId
                         into startStationJoineds
                     from startStationJoined in startStationJoineds.DefaultIfEmpty()
                     let startStationDistance = startStationJoined.DistanceFromFirstStationInRoute
                     join endStation in endRouteStations on _route.Id equals endStation.RouteId
                         into endStationJoineds
                     from endStationJoined in endStationJoineds.DefaultIfEmpty()
                     let endStationDistance = endStationJoined.DistanceFromFirstStationInRoute
                     let distance = (endStationDistance - startStationDistance) > 0 ? endStationDistance - startStationDistance : _route.Distance - (startStationDistance - endStationDistance)
                     orderby distance ascending

                     select new
                     {
                         RouteId = _route.Id,
                         StartStationIndex = startStationJoined.Index,
                         EndStationIndex = endStationJoined.Index,
                         Distance = distance
                     })
                    .Take(3)
                    .ToListAsync();

            var routeDic = query.ToDictionary(x => x.RouteId, x => x);
            var routeIds = query.Select(x => x.RouteId);
            var matchRoutes = await _unitOfWork.Routes.List(route => routeIds.Contains(route.Id)).MapTo<BookerRouteViewModel>(_mapper).ToListAsync();

            foreach(var route in matchRoutes)
            {
                var value = routeDic[route.Id];

                var startStationIndex = value.StartStationIndex;
                var endStationIndex = value.EndStationIndex;

                if(startStationIndex <= endStationIndex)
                {
                    route.Stations = route.Stations
                    .Where(station => station.Index >= startStationIndex && station.Index <= endStationIndex)
                    .OrderBy(station => station.Index)
                    .ToList();
                }
                else
                {
                    var stationBeforeEndStation = route.Stations
                    .Where(station => station.Index <= endStationIndex)
                    .ToList();

                    var stationAfterStartStation = route.Stations
                    .Where(station => station.Index >= startStationIndex)
                    .ToList();

                    route.Stations = stationAfterStartStation.Concat(stationBeforeEndStation).ToList();
                }

                route.Fee = Fee.CaculateBookingFee(dto.BookingType, dto.VehicleType, value.Distance, dto.StartAt, dto.EndAt);
            }

            return successResponse.SetData(matchRoutes);
        }

        public async Task<Response> GetRoutesByPairsOfStation(List<int> startStationIds, List<int> endStationIds, Response successResposne)
        {
            ////var routeStations =
            ////    _unitOfWork.RouteStations
            ////    .List(routeStation =>
            ////        startStationIds.Contains(routeStation.StationId) ||
            ////        endStationIds.Contains(routeStation.StationId));

            //var startRouteStations =
            //     _unitOfWork.RouteStations
            //    .List(routeStation =>
            //        startStationIds.Contains(routeStation.StationId));

            //var endRouteStations =
            //     _unitOfWork.RouteStations
            //    .List(routeStation =>
            //        endStationIds.Contains(routeStation.StationId));

            //var routes =
            //    _unitOfWork.Routes
            //    .List(route =>
            //        route.Status == StatusTypes.Route.Active &&
            //        route.RouteStations
            //        .Exists(routeStation => startStationIds.Contains(routeStation.StationId)) &&
            //        route.RouteStations
            //        .Exists(routeStation => endStationIds.Contains(routeStation.StationId)));

            //var result =
            //    (from route in routes
            //     join startRouteStation in startRouteStations on route.Id equals startRouteStation.RouteId
            //     join endRouteStation in endRouteStations on route.Id equals endRouteStation.RouteId
            //     orderby endRouteStation.DistanceFromFirstStationInRoute - startRouteStation.DistanceFromFirstStationInRoute
            //     select new
            //     {
            //         Route = route,
            //         StartRouteStation = startRouteStation,
            //         EndRouteStation = endRouteStation
            //     }

            //     )

            //var routes = 
            //    await _unitOfWork.Routes
            //    .List(route => 
            //        route.RouteStations
            //        .Exists(routeStation => startStationIds.Contains(routeStation.StationId)) &&
            //        route.RouteStations
            //        .Exists(routeStation => endStationIds.Contains(routeStation.StationId)))
            //    .GroupBy(route => route.Id)
            //    .ToListAsync();

            //rou
            return null;
        }
    }
}
