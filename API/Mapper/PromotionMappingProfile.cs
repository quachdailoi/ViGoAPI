using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class PromotionMappingProfile : Profile
    {
        private readonly IFileService _fileService;
        public PromotionMappingProfile(IFileService fileService)
        {
            _fileService = fileService;
            CreateMap<Promotion, PromotionViewModel>()
                .ForMember(
                    dest => dest.FilePath,
                    opt => opt.MapFrom(promotion => promotion.File == null ? null : _fileService.GetPresignedUrl(promotion.File.Path))
                );
        }
    }
}
