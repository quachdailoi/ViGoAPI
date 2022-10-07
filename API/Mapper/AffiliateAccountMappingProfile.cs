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
        }
    }
}
