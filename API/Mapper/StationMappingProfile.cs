using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class StationMappingProfile : Profile
    {
        public StationMappingProfile()
        {
            CreateMap<Station, StationViewModel>();

            CreateMap<Station, StationInRouteViewModel>()
                .ForMember(
                    dest => dest.Index,
                    opt => opt.MapFrom(
                        src => src.RouteStations.First().Index))
                //.ForMember(
                //    dest => dest.DistanceFromFirstStationInRoute,
                //    opt => opt.MapFrom(
                //        src => src.RouteStations.First().DistanceFromFirstStationInRoute))
                .IncludeBase<Station, StationViewModel>();

            CreateMap<StationDTO, Station>();

            CreateMap<CreateStationRequest, StationDTO>()
                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(
                            src => $"{src.Street}, {src.Ward}, {src.District}, {src.Province}"
                        ));

            CreateMap<GetRouteFeeRequest, StationWithScheduleDTO>()
                .ForMember(
                    dest => dest.StartAt,
                    otp => otp.MapFrom(
                            src => new DateOnly().ParseExact(src.StartAt)))
                .ForMember(
                    dest => dest.EndAt,
                    otp => otp.MapFrom(
                            src => new DateOnly().ParseExact(src.EndAt)));
        }
    }
}
