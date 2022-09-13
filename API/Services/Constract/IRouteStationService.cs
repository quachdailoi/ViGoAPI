using Domain.Entities;

namespace API.Services.Constract
{
    public interface IRouteStationService
    {
        Task<List<RouteStation>> Create(List<RouteStation> routeStations);
    }
}
