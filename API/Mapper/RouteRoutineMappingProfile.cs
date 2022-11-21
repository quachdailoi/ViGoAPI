using API.Models;
using API.Models.Requests;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class RouteRoutineMappingProfile : Profile
    {
        public RouteRoutineMappingProfile()
        {
            CreateMap<CreateRouteRoutineRequest, RouteRoutine>()
                .ForMember(
                    dest => dest.RouteId,
                    opt => opt.MapFrom(x => x.RouteId)
                )
                .ForMember(
                    dest => dest.StartAt,
                    opt => opt.MapFrom(x => x.StartAtParsed)
                )
                .ForMember(
                    dest => dest.EndAt,
                    opt => opt.MapFrom(x => x.EndAtParsed)
                )
                .ForMember(
                    dest => dest.StartTime,
                    opt => opt.MapFrom(x => x.StartTimeParsed)
                )
                .ForMember(
                    dest => dest.EndTime,
                    opt => opt.MapFrom(x => x.EndTimeParsed)
                )
                .ReverseMap();

            CreateMap<RouteRoutine, RouteRoutineViewModel>()
                .ForMember(
                    dest => dest.Distance,
                    opt => opt.MapFrom(x => x.Route.Distance)
                )
                .ForMember(
                    dest => dest.RouteCode,
                    opt => opt.MapFrom(x => x.Route.Code)
                )
                .ForMember(
                    dest => dest.Stations,
                    opt => opt.MapFrom(x => x.Route.RouteStations.OrderBy(x => x.Index).Select(x => x.Station))
                ).ReverseMap();
        }
    }
}
