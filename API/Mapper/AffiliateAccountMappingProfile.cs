using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class AffiliateAccountMappingProfile : Profile
    {
        public AffiliateAccountMappingProfile()
        {
            CreateMap<AffiliateAccount, AffiliateAccountDTO>()
                .ReverseMap();

            CreateMap<MomoLinkWalletNotificationRequest, GetMomoTokenRequest>()
                .ReverseMap();

            CreateMap<AffiliateAccount, AffiliateAccountViewModel>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(
                        src => src.AffiliateParty.Id))
                .ForMember(
                    dest => dest.Name,
                    otp => otp.MapFrom(
                        src => src.AffiliateParty.Name));
        }
    }
}
