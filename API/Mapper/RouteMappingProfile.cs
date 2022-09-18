using API.Extensions;
using API.Mapper.Action;
using API.Mapper.Resolver;
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
                //.AfterMap<AddStationToStepAction>();
                //.ForMember(
                //    dest => dest.Steps,
                //    opt => opt.MapFrom<StepResolver>()
                //);

            //CreateMap<Step, StepViewModel>();
        }
    }
}
