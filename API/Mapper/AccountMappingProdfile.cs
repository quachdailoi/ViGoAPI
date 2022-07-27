using API.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class AccountMappingProdfile : Profile
    {
        public AccountMappingProdfile()
        {
            CreateMap<Account, UserViewModel>()
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(
                        src => src.Registration    
                    )
                )
                .IncludeMembers(
                    s => s.User,
                    s => s.Role
                )
                .ReverseMap();
        }
    }
}
