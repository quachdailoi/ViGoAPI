using API.Models;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<Report, ReportViewModel>();
        }
    }
}
