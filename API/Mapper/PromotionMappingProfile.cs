using API.Models;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class PromotionMappingProfile : Profile
    {
        public PromotionMappingProfile()
        {
            CreateMap<Promotion, PromotionViewModel>();
        }
    }
}
