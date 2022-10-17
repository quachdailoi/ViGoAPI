using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class WalletMappingProfile : Profile
    {
        public WalletMappingProfile()
        {
            CreateMap<Wallet, WalletViewModel>()
                .ForMember(
                    dest => dest.StatusName,
                    opt => opt.MapFrom(
                            src => src.Status.DisplayName())); ;
        }
    }
}
