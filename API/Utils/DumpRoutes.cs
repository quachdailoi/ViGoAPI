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

            var routeService = scope.GetService<IRouteService>();
            var stationService = scope.GetService<IStationService>();
            var rapidApiService = scope.GetService<IRapidApiService>();
            var routeRoutineService = scope.GetService<IRouteRoutineService>();

            if (routeService.ExistSeedData().Result) return;

            var stationIds = GetListStationIdsToDumpRoutes()[1];

            var stationDtos = await stationService.GetStationDTOsByIds(stationIds);
            var newRoute = await rapidApiService.CreateRouteByListOfStation(stationDtos);

            var routeRoutines = new List<RouteRoutine>
            {
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[1],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("09:00:00"),
                    EndTime = TimeOnly.Parse("09:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(3),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[1],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("11:00:00"),
                    EndTime = TimeOnly.Parse("11:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(3),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[1],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("13:00:00"),
                    EndTime = TimeOnly.Parse("13:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(3),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[2],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("09:00:00"),
                    EndTime = TimeOnly.Parse("09:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(2),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[2],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("15:00:00"),
                    EndTime = TimeOnly.Parse("15:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(2),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[2],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("17:00:00"),
                    EndTime = TimeOnly.Parse("17:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(2),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[3],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("09:30:00"),
                    EndTime = TimeOnly.Parse("09:30:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(3),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[3],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("11:30:00"),
                    EndTime = TimeOnly.Parse("11:30:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(3),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[3],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("13:40:00"),
                    EndTime = TimeOnly.Parse("13:40:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(3),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[3],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("15:00:00"),
                    EndTime = TimeOnly.Parse("15:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(3),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[3],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("17:30:00"),
                    EndTime = TimeOnly.Parse("17:30:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(3),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[1],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("19:00:00"),
                    EndTime = TimeOnly.Parse("18:45:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(3),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[0],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("07:00:00"),
                    EndTime = TimeOnly.Parse("07:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(1),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[0],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("08:00:00"),
                    EndTime = TimeOnly.Parse("08:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(1),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[0],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("09:00:00"),
                    EndTime = TimeOnly.Parse("09:00:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(1),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[0],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("16:30:00"),
                    EndTime = TimeOnly.Parse("16:30:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(1),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[1],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("17:30:00"),
                    EndTime = TimeOnly.Parse("17:30:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(1),
                },
                new RouteRoutine
                {
                    UserId = GetListDriverIdsToDumpRouteRoutines[1],
                    RouteId = newRoute.Id,
                    StartTime = TimeOnly.Parse("18:30:00"),
                    EndTime = TimeOnly.Parse("18:30:00").AddMinutes(newRoute.Duration/60),
                    StartAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy"),
                    EndAt = DateOnly.ParseExact("01-10-2022","dd-MM-yyyy").AddMonths(1),
                },
            };

            routeRoutines = await routeRoutineService.CreateRouteRoutines(routeRoutines);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public static List<int> GetListDriverIdsToDumpRouteRoutines = new List<int>{ 1, 2, 3, 4};
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
                },
                new()
                {
                    25, 26, 27, 28,29, 30, 33, 30, 33, 20, 88
                }
            };
        }

    }
}
