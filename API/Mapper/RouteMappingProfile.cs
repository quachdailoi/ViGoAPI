using API.Extensions;
using API.Models;
using AutoMapper;
using Domain.Shares.Classes;

namespace API.Mapper
{
    public class RouteMappingProfile : Profile
    {
        public RouteMappingProfile()
        {
            CreateMap<Domain.Entities.Route, RouteViewModel>()
                .ForMember(
                    dest => dest.Stations,
                    opt => opt.MapFrom(src => src.RouteStations.Select(item => item.Station)));

            CreateMap<Domain.Entities.Route, BookerRouteViewModel>()
                .IncludeBase<Domain.Entities.Route, RouteViewModel>();
        }
    }
}
