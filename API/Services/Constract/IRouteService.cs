﻿using API.Models;
using API.Models.DTO;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IRouteService
    {
        Task<List<Domain.Entities.Route>> Create(List<Domain.Entities.Route> routes);      
        Task<Response> GetSteps(Location startPoint, Location endPoint);
        Task<Response> CreateRange(List<RouteDTO> routes, Response successResponse, Response dupplicateResponse, Response errorResponse);
        Task<Response> GetAll(Response successResponse);
        Task<bool> IsExistData();
        Task<List<RouteViewModel>> GetRouteByListOfStations(Station startStation, List<Tuple<Station, double, object>> stepStations);
        Task<Response> GetRouteByPairOfStation(int startStationId, int endStationId, Response successResponse);
        Task<Response> GetStepsByPairOfStations(Station startStation, Station endStation, VehicleTypes vehicleType,Response successResposne);
    }
}
