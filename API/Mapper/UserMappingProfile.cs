using API.Mapper.CustomResolver;
using API.Models;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(
                    dest => dest.Email, 
                    opt => opt.MapFrom<EmailResolver>()
                )
                .ForMember(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom<PhoneNumberResolver>()
                )
                .ForMember(
                    dest => dest.RoleName,
                    opt => opt.MapFrom<RoleNameResolver>()
                );
        }
    }
}
