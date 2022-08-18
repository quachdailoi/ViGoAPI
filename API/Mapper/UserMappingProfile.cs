using API.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(
                    dest => dest.Gmail,
                    opt => opt.MapFrom(user => user.Accounts.Where(x => x.RegistrationType == RegistrationTypes.Gmail).FirstOrDefault().Registration)
                )
                .ForMember(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(user => user.Accounts.Where(x => x.RegistrationType == RegistrationTypes.Phone).FirstOrDefault().Registration)
                )
                .ForMember(
                    dest => dest.RoleName,
                    opt => opt.MapFrom(user => user.Accounts.FirstOrDefault().Role.Name)
                )
                .ForMember(
                    dest => dest.HasVerifiedGmail,
                    opt => opt.MapFrom(user => user.Accounts.Where(x => x.RegistrationType == RegistrationTypes.Gmail).FirstOrDefault().Verified)
                )
                .ForMember(
                    dest => dest.HasVerifiedPhoneNumber,
                    opt => opt.MapFrom(user => user.Accounts.Where(x => x.RegistrationType == RegistrationTypes.Phone).FirstOrDefault().Verified)
                )
                .ForMember(
                    dest => dest.AvatarUrl,
                    opt => opt.MapFrom(user => user.File == null ? null : user.File.Path)
                )
                .ForMember(
                    dest => dest.AvatarCode,
                    opt => opt.MapFrom(user => user.File == null ? Guid.Empty : user.File.Code)
                );
        }
    }
}
