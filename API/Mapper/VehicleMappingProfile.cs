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
            CreateMap<VehicleType, VehicleTypeViewModel>();

            CreateMap<VehicleType, VehicleTypeWithFareViewModel>();

            CreateMap<Fare, FareViewModel>();

            CreateMap<FareTimeline, FareTimeLineViewModel>();

            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(
                    dest => dest.Type,
                    otp => otp.MapFrom(
                        src => src.VehicleType.Name));
        }
    }
}
