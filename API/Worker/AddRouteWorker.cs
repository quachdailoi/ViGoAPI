using API.Services.Constract;
using API.Utils;

namespace API.Worker
{
    public class AddRouteWorker : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger<AddRouteWorker> _logger;

        public AddRouteWorker(IServiceProvider provider, ILogger<AddRouteWorker> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _provider.CreateAsyncScope().ServiceProvider;

            var stationService = scope.GetRequiredService<IStationService>();
            var rapidApiService = scope.GetRequiredService<IRapidApiService>();

            var listOfStationIds = DumpRoutes.GetListStationIdsToDumpRoutes();

            foreach(var stationIds in listOfStationIds)
            {
                var stationDtos = await stationService.GetStationDTOsByIds(stationIds);
                var newRoute = await rapidApiService.CreateRouteByListOfStation(stationDtos);

                _logger.LogInformation($"Route added with ID: {newRoute.Id}");
                Console.WriteLine($"Route added with ID: {newRoute.Id}");
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
