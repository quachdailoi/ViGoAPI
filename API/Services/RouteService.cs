using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using API.Services.Constract;
using API.Utilities;
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
    public class RouteService : BaseService, IRouteService
    {
        public RouteService(IAppServices appServices) : base(appServices)
        {
        }

        public Task<List<Domain.Entities.Route>> Create(List<Domain.Entities.Route> routes)
        {
            return UnitOfWork.Routes.Add(routes);
        }

        public async Task<Response> CreateRange(List<RouteDTO> routes, Response successResponse, Response dupplicateResponse, Response errorResponse)
        {
            var routeEntities = Mapper.Map<List<Domain.Entities.Route>>(routes);

            //check duplicate

            routeEntities = await Create(routeEntities);

            if(routeEntities == null) return errorResponse;

            return successResponse.SetData(routeEntities);
        }

        public async Task<Response> GetAll(StartStationRequest request, Response successResponse)
        {
            var routes = UnitOfWork.Routes.List(route => route.Status == Routes.Status.Active);

            if (!string.IsNullOrEmpty(request.StartStationCode))
            {
                routes = routes.Where(route => route.RouteStations.Where(rs => rs.Station.Code.ToString() == request.StartStationCode).Any());
            }

            var result = await routes.MapTo<RouteViewModel>(Mapper, AppServices).ToListAsync();

            if (result != null && result.Count != 0) foreach(var route in result) route.ProcessStation();

            return successResponse.SetData(result);
        }

        public Task<bool> ExistSeedData()
        {
            return UnitOfWork.Routes.List().AnyAsync();
        }


        public async Task<Response> GetRouteFeeByPairOfStation(StationWithScheduleDTO dto, Response invalidStationResponse, Response invalidVehicleTypeResponse, Response successResponse, Response notFoundResponse)
        {
            var pairOfStation = await AppServices.Station.GetPairOfStation(dto.StartStationCode, dto.EndStationCode);

            var startStationId = pairOfStation.Item1?.Id;
            var endStationId = pairOfStation.Item2?.Id;

            if (!startStationId.HasValue || !endStationId.HasValue)
                return invalidStationResponse;

            dto.StartStationId = startStationId.Value;
            dto.EndStationId = endStationId.Value;

            VehicleType? vehicleType = await AppServices.VehicleType.GetByCode(dto.VehicleTypeCode);

            if (vehicleType == null) return invalidVehicleTypeResponse;

            dto.VehicleTypeId = vehicleType.Id;

            var routeViewModels =
                await UnitOfWork.Routes
                .List(route =>
                    route.Status == Routes.Status.Active &&
                    route.RouteStations.Select(routeStation => routeStation.StationId).Contains(dto.StartStationId) &&
                    route.RouteStations.Select(routeStation => routeStation.StationId).Contains(dto.EndStationId)
                    //&&
                    //route.RouteRoutines.Any(routeRoutine => 
                    //    routeRoutine.Status == RouteRoutines.Status.Active && 
                    //    routeRoutine.User.Vehicle.VehicleTypeId == dto.VehicleTypeId)
                    )
                .MapTo<BookerRouteViewModel>(Mapper,AppServices)
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
                    routeViewModel.Fee = await AppServices.Fare.CaculateFeePerTrip(dto.VehicleTypeId, dto.StartAt, dto.EndAt, dto.DayOfWeeks, routeViewModel.Distance, dto.Time);
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
            return await UnitOfWork.Routes.CreateRoute(route);
        }

        public Task<Domain.Entities.Route> GetRouteByCode(string code)
        {
            return UnitOfWork.Routes.GetRouteByCode(code);
        }

        public IQueryable<Domain.Entities.Route> GetRouteByCode(Guid code)
        {
            return UnitOfWork.Routes.GetRouteByCode(code);
        }

        public async Task<RouteViewModel?> UpdateRoute(Domain.Entities.Route route, List<StationDTO> stationDTOs)
        {
            await UnitOfWork.CreateTransactionAsync();

            var routeViewModel = await AppServices.RapidApi.UpdateRouteByListOfStation(route, stationDTOs);

            if (routeViewModel == null)
            {
                await UnitOfWork.Rollback();
                return null;
            }
            await UnitOfWork.CommitAsync();
            return routeViewModel;
        }

        public IQueryable<Domain.Entities.Route> GetRoute(string code)
        {
            return UnitOfWork.Routes.GetRouteByCode(new Guid(code));
        }

        public bool CheckRouteWasBooked(int routeId)
        {
            var bookings = UnitOfWork.BookingDetails.List(x => x.Status == BookingDetails.Status.Pending ||
                x.Status == BookingDetails.Status.Ready || x.Status == BookingDetails.Status.Started)
                .Include(x => x.Booking.StartRouteStation.Route)
                .Select(x => new
                {
                    BookingId = x.BookingId,
                    Booking = x.Booking
                }).ToList()
                .GroupBy(x => x.BookingId)
                .SelectMany(x => x.Select(y => y.Booking));

            return bookings.Select(x => x.StartRouteStation.Route.Id).DistinctBy(x => x).Contains(routeId);
        }

        public Task<bool> DeleteRoute(Domain.Entities.Route route)
        {
            return UnitOfWork.Routes.Remove(route);
        }

        public PagingViewModel<IQueryable<RouteViewModel>>? GetRoutes(string searchValue, PagingRequest paging)
        {
            searchValue = searchValue.ToLower();
            var routes =
                UnitOfWork.Routes.List(
                    x => x.Code.ToString().Contains(searchValue) ||
                    x.Name.ToLower().Contains(searchValue) ||
                    x.RouteStations.Any(rs => rs.Station.Name.ToLower().Contains(searchValue) || rs.Station.Address.ToLower().Contains(searchValue))
                )
                .PagingMap<Domain.Entities.Route, RouteViewModel>(Mapper, paging.Page, paging.PageSize, AppServices);

            return routes;
        }

        public IQueryable<RouteViewModel>? GetRoutes(string searchValue)
        {
            var routes =
                UnitOfWork.Routes.List(
                    x => x.Code.ToString().TrimContainsIgnoreCase(searchValue) ||
                    x.Name.TrimContainsIgnoreCase(searchValue) ||
                    x.RouteStations.Any(rs => rs.Station.Name.TrimContainsIgnoreCase(searchValue) || rs.Station.Address.TrimContainsIgnoreCase(searchValue))
                ).MapTo<RouteViewModel>(Mapper, AppServices);

            return routes;
        }
    }
}
