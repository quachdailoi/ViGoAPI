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

        public async Task<Response> Get(Response successResponse)
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

        public async Task<Response> GetWithFare(Response successResponse)
        {
            var vehicleTypes =
                (await UnitOfWork.VehicleTypes
                    .List(vehicleType =>
                        vehicleType.Status == VehicleTypes.Status.Active)
                    .MapTo<VehicleTypeWithFareViewModel>(Mapper)
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

        public Task<List<VehicleType>> GetWithFare() 
            => UnitOfWork.VehicleTypes
                    .List(vehicleType => vehicleType.Status == VehicleTypes.Status.Active)
                    .Include(vehicleType => vehicleType.Fare)
                    .ThenInclude(fare => fare.FareTimelines)
                    .ToListAsync();

    }
}
