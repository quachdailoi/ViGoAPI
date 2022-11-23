using API.Models;
using API.Models.DTO;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            IAppServices? service = null;

            CreateMap<Report, ReportViewModel>()
                .ForMember(
                    dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(
                    dest => dest.UpdatedAdmin,
                    opt => opt.MapFrom(src => service.User.GetById(src.UpdatedBy)));

            CreateMap<Report, ReportDTO>().ReverseMap();
        }
    }
}
