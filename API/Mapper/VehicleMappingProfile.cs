using API.Models;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class VehicleMappingProfile : Profile
    {
        public VehicleMappingProfile()
        {
            CreateMap<VehicleType, VehicleTypeViewModel>();
        }
    }
}
