using Domain.Entities;

namespace API.Services.Constract
{
    public interface IRouteStationService
    {
        Task<List<RouteStation>> Create(List<RouteStation> routeStations);
        IQueryable<Station> GetQueryableStationsFromStartToEnd(RouteStation startRouteStation, RouteStation endRouteStation);
        Task<List<Station>> GetOrderedStationsInRouteAsync(RouteStation startRouteStation, RouteStation endRouteStation);
        List<Station> GetOrderedStationsInRoute(RouteStation startRouteStation, RouteStation endRouteStation);
        Task<RouteStation?> GetRouteStation(Guid endStationCode, RouteStation startRouteStation);
        Task<RouteStation?> GetStartRouteStation(Guid routeCode, Guid startStationCode);
    }
}
