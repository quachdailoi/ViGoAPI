﻿using API.Models;
using API.Models.DTO;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IStationService
    {
        Task<List<Station>> Create(List<Station> stations);
        Task<Response> Create(List<StationDTO> stations, int userId, Response successResposne, Response duplicateResponse, Response errorResponse);
        Task<Response> Get(Response successResponse);
        Task<List<Station>> GetByCode(List<Guid> stationCodes);
        bool CheckDuplicateStations(List<StationDTO> stations);
        Task<bool> ExistSeedData();
        Task<List<Tuple<Station, double, object?>>?> GetStationSteps(Station startStation, Station endStation);
    }
}
