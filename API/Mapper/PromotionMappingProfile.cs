using API.Extensions;
using API.Mapper.MappingSupports;
using API.Models;
using API.Models.Requests;
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

            CreateMap<Promotion, AdminPromotionViewModel>()
                .ForMember(
                    dest => dest.FilePath,
                    opt => opt.MapFrom(src => src.File.GetFilePath(service))
                );

            CreateMap<PromotionCondition, PromotionConditionViewModel>()
                .ForMember(
                    dest => dest.ValidFromData,
                    opt => opt.MapFrom(src => src.ValidFrom))
                .ForMember(
                    dest => dest.ValidUntilData,
                    opt => opt.MapFrom(src => src.ValidUntil));

            CreateMap<CreatePromotionRequest, Promotion>()
                .ForMember(
                    dest => dest.File,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Code,
                    opt => opt.Ignore());

            CreateMap<CreatePromotionRequest, PromotionCondition>()
                .ForMember(
                    dest => dest.ValidFrom,
                    opt => opt.MapFrom(
                        src => src.ValidFromParsed()))
                .ForMember(
                    dest => dest.ValidUntil,
                    opt => opt.MapFrom(
                        src => src.ValidUntilParsed()));

            CreateMap<UpdatePromotionRequest, Promotion>()
                .ForMember(
                    dest => dest.File,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Code,
                    opt => opt.Ignore());

            CreateMap<UpdatePromotionRequest, PromotionCondition>()
                .ForMember(
                    dest => dest.ValidFrom,
                    opt => opt.MapFrom(
                        src => src.ValidFromParsed()))
                .ForMember(
                    dest => dest.ValidUntil,
                    opt => opt.MapFrom(
                        src => src.ValidUntilParsed()));
        }
    }
}
