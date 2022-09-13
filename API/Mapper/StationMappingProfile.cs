using API.Models;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class StationMappingProfile : Profile
    {
        public StationMappingProfile()
        {
            CreateMap<Station, StationViewModel>();
        }
    }
}
