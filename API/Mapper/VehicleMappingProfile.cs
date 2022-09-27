using API.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class VehicleMappingProfile : Profile
    {
        public VehicleMappingProfile()
        {
            CreateMap<VehicleType, VehicleTypeViewModel>()
                .ForMember(
                    dest => dest.TypeName,
                    opt => opt.MapFrom(
                        src => src.Type.GetString()));
        }
    }
}
