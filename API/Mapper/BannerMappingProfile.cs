using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class BannerMappingProfile : Profile
    {
        private readonly IFileService _fileService;
        public BannerMappingProfile(IFileService fileService)
        {
            _fileService = fileService;
            CreateMap<Banner, BannerViewModel>()
                .ForMember(
                    model => model.FilePath,
                    config => config.MapFrom(
                        banner => _fileService.GetPresignedUrl(banner.File.Path)
                    )
                );
        }
    }
}
