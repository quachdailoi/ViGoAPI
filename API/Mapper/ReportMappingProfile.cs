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
            CreateMap<Report, ReportViewModel>();

            CreateMap<Report, ReportDTO>().ReverseMap();
        }
    }
}
