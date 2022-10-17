using API.Extensions;
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
                        src => src.Type.DisplayName()))
                .ForMember(
                    dest => dest.StatusName,
                    opt => opt.MapFrom(
                            src => src.Status.DisplayName()));

            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(
                    dest => dest.Type,
                    otp => otp.MapFrom(
                        src => src.VehicleType.Type.DisplayName()));
        }
    }
}
