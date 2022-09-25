using API.Services.Constract;
using Domain.Entities;
using Domain.Shares.Classes;
using Domain.Shares.Utils;

namespace API.Utils
{
    public class DumpRoutes : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DumpRoutes(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _serviceProvider.CreateScope().ServiceProvider;

            var _routeService = scope.GetService<IRouteService>();
            var _routeStationService = scope.GetService<IRouteStationService>();

            if (await _routeService.IsExistData()) return;

            var routes = DumpData.DumpRoutes(20);
            var routeStations = DumpData.DumpRouteStations(routes);


            await _routeService.Create(routes);

            await _routeStationService.Create(routeStations);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public static List<List<int>> GetListStationIdsToDumpRoutes()
        {
            return new()
            {
                new()
                {
                    12, 13, 14, 15, 16, 17, 18, 19,20,21, 88, 22, 23, 24,
                },
                new()
                {
                    12,13,14,16,25,26,27,28,29,30,31,32,33,20,21,88,22,23,24
                },
                new()
                {
                    39,40,41,42,43,44,41,40,39
                },
                new()
                {
                    45,46,50,51,52,51,50,46,45
                },
                new()
                {
                    53,54,55,56,55,54
                },
                new()
                {
                    57,58,59,58,57
                },
                new()
                {
                    60,61,62,63,62,61,60
                },
                new()
                {
                    64,65,66,65,64
                },
                new()
                {
                    67,68,69,70,69,68,67
                },
                new()
                {
                    71,72,73,74,75
                },
                new()
                {
                    76,77,78,79,80,81,82
                },
                new()
                {
                    83,84,85,86,87,86,85,84,83
                }
            };
        }

    }
}
