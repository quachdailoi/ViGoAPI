using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class StationService : IStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<Station>> Create(List<Station> stations)
        {
            return _unitOfWork.Stations.Add(stations);
        }
        public bool CheckDuplicateStations(List<StationDTO> stations)
        {
            return stations.DistinctBy(station => $"{station.Latitude}|{station.Longitude}").Any();
        }
        private Task<bool> CheckDulpicateStationsWithinDatabase(List<StationDTO> stations)
        {
            return _unitOfWork.Stations.List(station => stations.Exists(_station => _station.Latitude == station.Latitude &&
                                                                                               _station.Longitude == station.Longitude) &&
                                                                               station.Status == StatusTypes.Station.Active)
                                                              .AnyAsync();
        }
        public async Task<Response> Create(List<StationDTO> stations, int userId, Response successResponse, Response duplicateResponse, Response errorResponse)
        {
            
            if (!(await CheckDulpicateStationsWithinDatabase(stations))) return duplicateResponse;

            foreach(var station in stations)
            {
                station.CreatedBy = userId;
                station.UpdatedBy = userId;
            };

            var stationEntities = _mapper.Map<List<Station>>(stations);

            stationEntities = await _unitOfWork.Stations.Add(stationEntities);

            if (stationEntities == null) return errorResponse;

            return successResponse.SetData(_mapper.Map<List<StationViewModel>>(stationEntities));

        }

        public Task<bool> ExistSeedData()
        {
            return _unitOfWork.Stations.List().AnyAsync();
        }

        public async Task<Response> Get(Response successResponse)
        {
            var stations = await _unitOfWork.Stations.List(station => station.Status == StatusTypes.Station.Active).MapTo<StationViewModel>(_mapper).ToListAsync();

            return successResponse.SetData(stations);
        }
    }
}
