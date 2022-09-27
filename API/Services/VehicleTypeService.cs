using API.Extensions;
using API.Models;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace API.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public VehicleTypeService(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Response> GetAll(Response successResponse)
        {
            var vehicleTypes = 
                (await _unitOfWork.VehicleTypes
                    .List(vehicleType => 
                        vehicleType.Status == VehicleTypes.Status.Active)
                    .MapTo<VehicleTypeViewModel>(_mapper)
                    .ToListAsync());

            var vehicleTypesGrouping = vehicleTypes
                .GroupBy(e => new { Type = e.Type, TypeName = e.TypeName })
                .Select(e => new
                {
                    Type = e.Key.Type,
                    TypeName = e.Key.TypeName,
                    VehicleTypes = e.ToList()
                });

            return successResponse.SetData(vehicleTypesGrouping);
        }

        public Task<VehicleType?> GetByCode(Guid code) => 
            _unitOfWork.VehicleTypes
            .List(vehicleType => 
                vehicleType.Code == code && vehicleType.Status == VehicleTypes.Status.Active)
            .FirstOrDefaultAsync();

        public async Task<List<VehicleType>> GetWithFare()
        {
            var vehicleTypeWithFaresCacheStr = await _cache.GetStringAsync("vehicle_type_fares");

            var vehicleTypeWithFares = new List<VehicleType>();

            if(vehicleTypeWithFaresCacheStr == null)
            {
                vehicleTypeWithFares =
                    await _unitOfWork.VehicleTypes
                    .List(vehicleType => vehicleType.Status == VehicleTypes.Status.Active)
                    .Include(vehicleType => vehicleType.Fare)
                    .ThenInclude(fare => fare.FareTimelines)
                    .ToListAsync();



                vehicleTypeWithFaresCacheStr = JsonConvert.SerializeObject(vehicleTypeWithFares , new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                await _cache.SetStringAsync("vehicle_type_fares", vehicleTypeWithFaresCacheStr);
            }
            else
            {
                vehicleTypeWithFares = JsonConvert.DeserializeObject<List<VehicleType>>(vehicleTypeWithFaresCacheStr);
            }

            return vehicleTypeWithFares;
        }
    }
}
