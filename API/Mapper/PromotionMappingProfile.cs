using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class PromotionMappingProfile : Profile
    {
        public PromotionMappingProfile()
        {
            IAppServices? service = null;

            CreateMap<Promotion, PromotionViewModel>()
                .ForMember(
                    dest => dest.FilePath,
                    opt => opt.MapFrom(src => src.File.GetFilePath(service))
                )
                .ForMember(
                    dest => dest.ValidFrom,
                    otp => otp.MapFrom(promotion => promotion.PromotionCondition.ValidFrom)
                )
                .ForMember(
                    dest => dest.ValidUntil,
                    otp => otp.MapFrom(promotion => promotion.PromotionCondition.ValidUntil)
                );
        }
    }
}
