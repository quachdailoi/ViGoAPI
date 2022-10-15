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
    public class VehicleTypeService : BaseService, IVehicleTypeService
    {
        public VehicleTypeService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<Response> GetAll(Response successResponse)
        {
            var vehicleTypes = 
                (await UnitOfWork.VehicleTypes
                    .List(vehicleType => 
                        vehicleType.Status == VehicleTypes.Status.Active)
                    .MapTo<VehicleTypeViewModel>(Mapper)
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
            UnitOfWork.VehicleTypes
            .List(vehicleType => 
                vehicleType.Code == code && vehicleType.Status == VehicleTypes.Status.Active)
            .FirstOrDefaultAsync();
        private Task<List<VehicleType>> GetAllWithFare() =>
            _unitOfWork.VehicleTypes
                    .List(vehicleType => vehicleType.Status == VehicleTypes.Status.Active)
                    .Include(vehicleType => vehicleType.Fare)
                    .ThenInclude(fare => fare.FareTimelines)
                    .ToListAsync();
        private Task SetVehicleTypeCache(out List<VehicleType> vehicleTypes)
        {
            vehicleTypes = GetAllWithFare().Result;

            var vehicleTypeCacheStr = JsonConvert.SerializeObject(vehicleTypes, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return _cache.SetStringAsync("vehicle_type_fares", vehicleTypeCacheStr);
        }
        public async Task<List<VehicleType>> GetWithFare()
        {
            var vehicleTypeWithFaresCacheStr = await Cache.GetStringAsync("vehicle_type_fares");

            var vehicleTypeWithFares = new List<VehicleType>();

            if(vehicleTypeWithFaresCacheStr == null)
            {
                vehicleTypeWithFares =
                    await UnitOfWork.VehicleTypes
                    .List(vehicleType => vehicleType.Status == VehicleTypes.Status.Active)
                    .Include(vehicleType => vehicleType.Fare)
                    .ThenInclude(fare => fare.FareTimelines)
                    .ToListAsync();



                vehicleTypeWithFaresCacheStr = JsonConvert.SerializeObject(vehicleTypeWithFares , new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                await Cache.SetStringAsync("vehicle_type_fares", vehicleTypeWithFaresCacheStr);
            }
            else
            {
                try
                {
                    vehicleTypeWithFares = JsonConvert.DeserializeObject<List<VehicleType>>(vehicleTypeWithFaresCacheStr);
                }
                catch
                {
                    await SetVehicleTypeCache(out vehicleTypeWithFares);
                }
            }

            return vehicleTypeWithFares;
        }
    }
}
