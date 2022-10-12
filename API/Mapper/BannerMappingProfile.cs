using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class BannerMappingProfile : Profile
    {
        public BannerMappingProfile()
        {
            IAppServices? service = null;

            CreateMap<Banner, BannerViewModel>()
                .ForMember(
                    model => model.FilePath,
                    config => config.MapFrom(src => src.File.GetFilePath(service))
                );
        }
    }
}
