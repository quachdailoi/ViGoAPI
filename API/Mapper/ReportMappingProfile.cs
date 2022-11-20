using API.Models;
using API.Models.DTO;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<Report, ReportViewModel>()
                .ForMember(dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Report, ReportDTO>().ReverseMap();
        }
    }
}
