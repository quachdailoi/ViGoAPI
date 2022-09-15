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

            CreateMap<StationDTO, Station>();

            CreateMap<CreateStationRequest, StationDTO>()
                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(
                            src => $"{src.Street}, {src.Ward}, {src.District}, {src.Province}"
                        ));
        }
    }
}
