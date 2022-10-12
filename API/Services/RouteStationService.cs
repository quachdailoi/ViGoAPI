using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RouteStationService : BaseService, IRouteStationService
    {
        public RouteStationService(IAppServices appServices) : base(appServices)
        {
        }

        public Task<List<RouteStation>> Create(List<RouteStation> routeStations)
        {
            return UnitOfWork.RouteStations.Add(routeStations);
        }

        public IQueryable<Station> GetQueryableStationsFromStartToEnd(RouteStation startRouteStation, RouteStation endRouteStation)
        {
            int startIndex = startRouteStation.Index;
            int endIndex = endRouteStation.Index;
            int routeId = startRouteStation.RouteId;

            return UnitOfWork.RouteStations.List(x => x.RouteId == routeId && (x.Index >= startIndex && x.Index <= endIndex))
                .OrderBy(x => x.Index)
                .Select(x => x.Station);
        }

        public Task<List<Station>> GetOrderedStationsInRouteAsync(RouteStation startRouteStation, RouteStation endRouteStation)
        {
            return GetQueryableStationsFromStartToEnd(startRouteStation, endRouteStation).ToListAsync();
        }

        public List<Station> GetOrderedStationsInRoute(RouteStation startRouteStation, RouteStation endRouteStation)
        {
            return GetQueryableStationsFromStartToEnd(startRouteStation, endRouteStation).ToList();
        }

        public async Task<RouteStation?> GetRouteStation(Guid endStationCode, RouteStation startRouteStation)
        {
            var endStation = await AppServices.Station.GetStationByCodeAsync(endStationCode);

            if (endStation == null) return null;

            var endRouteStation = UnitOfWork.RouteStations.List(x => x.RouteId == startRouteStation.RouteId && x.StationId == endStation.Id && x.Index > startRouteStation.Index).FirstOrDefault();
        
            if (endRouteStation == null) return null;

            return endRouteStation;
        }

        public async Task<RouteStation?> GetStartRouteStation(Guid routeCode, Guid startStationCode)
        {
            var route = await AppServices.Route.GetRouteByCode(routeCode.ToString());

            var startStation = await AppServices.Station.GetStationByCodeAsync(startStationCode);

            if (route == null || startStation == null) return null;

            var startRouteStation = UnitOfWork.RouteStations.List(x => x.RouteId == route.Id && x.StationId == startStation.Id).Include(x => x.Route).FirstOrDefault();

            return startRouteStation;
        }
    }
}
