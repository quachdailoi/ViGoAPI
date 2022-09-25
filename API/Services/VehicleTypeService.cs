using API.Extensions;
using API.Models;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> GetAll(Response successResponse)
        {
            var vehicleTypes = 
                (await _unitOfWork.VehicleTypes
                    .List(vehicleType => 
                        vehicleType.Status == VehicleTypes.Status.Active)
                    .MapTo<VehicleTypeViewModel>(_mapper)
                    .ToListAsync())
                    .GroupBy(e => e.Type);

            return successResponse.SetData(vehicleTypes);
        }
    }
}
