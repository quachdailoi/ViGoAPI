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
                    model => model.Gmail,
                    config => config.MapFrom(
                        acc => acc.Registration
                    )
                )
                .ForMember(
                    model => model.PhoneNumber,
                    config => config.MapFrom(
                        acc => acc.Registration
                    )
                )
                .IncludeMembers(
                    s => s.User,
                    s => s.Role
                );
        }
    }
}
