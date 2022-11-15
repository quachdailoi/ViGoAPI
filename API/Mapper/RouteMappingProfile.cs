using API.Extensions;
using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Classes;

namespace API.Mapper
{
    public class RouteMappingProfile : Profile
    {
        public RouteMappingProfile()
        {
            IAppServices? service = null;

            CreateMap<Domain.Entities.Route, RouteViewModel>()
                .ForMember(
                    dest => dest.Stations,
                    opt => opt.MapFrom(src => src.RouteStations.Select(item => item.Station))
                ).ForMember(
                    dest => dest.UpdatedByAdmin,
                    opt => opt.MapFrom(src => service.User.GetUserById(src.UpdatedBy).ToList()[0])
                );

            CreateMap<Domain.Entities.Route, BookerRouteViewModel>()
                .IncludeBase<Domain.Entities.Route, RouteViewModel>();
        }
    }
}
