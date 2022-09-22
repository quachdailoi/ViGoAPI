﻿using API.Services.Constract;
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
    }
}
