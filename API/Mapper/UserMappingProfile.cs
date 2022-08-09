using API.Mapper.CustomResolver;
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

            //CreateProjection<User, UserViewModel>()
            //    .ForMember(
            //        dest => dest.Email,
            //        otp => otp.MapFrom(user => user.Accounts.Where(account => account.RegistrationType == RegistrationTypes.Email.GetInt()).FirstOrDefault().Registration)
            //    )
            //    .ForMember(
            //        dest => dest.PhoneNumber,
            //        otp => otp.MapFrom(user => user.Accounts.Where(account => account.RegistrationType == RegistrationTypes.Phone.GetInt()).FirstOrDefault().Registration)
            //    )
            //    .ForMember(
            //        dest => dest.RoleName,
            //        otp => otp.MapFrom(user => user.Accounts.FirstOrDefault().Role.Name)
            //    );     

        }
    }
}
