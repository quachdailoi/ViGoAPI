using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;
using System.Linq.Expressions;

namespace API.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            IAppServices? service = null;

            CreateMap<User, UserViewModel>()
                .ForMember(
                    dest => dest.Gmail,
                    opt => opt.MapFrom(src => src.Accounts.GetRegistration(RegistrationTypes.Gmail))
                )
                .ForMember(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => src.Accounts.GetRegistration(RegistrationTypes.Phone))
                )
                .ForMember(
                    dest => dest.RoleName,
                    opt => opt.MapFrom(src => src.Accounts.FirstOrDefault().Role.GetRoleName())
                )
                .ForMember(
                    dest => dest.HasVerifiedGmail,
                    opt => opt.MapFrom(src => src.Accounts.CheckVerifyAccount(RegistrationTypes.Gmail))
                )
                .ForMember(
                    dest => dest.HasVerifiedPhoneNumber,
                    opt => opt.MapFrom(src => src.Accounts.CheckVerifyAccount(RegistrationTypes.Phone))
                )
                .ForMember(
                    dest => dest.AvatarUrl,
                    opt => opt.MapFrom(src => src.File.GetFilePath(service))
                )
                .ForMember(
                    dest => dest.AvatarCode,
                    opt => opt.MapFrom(src => src.File.GetFileCode())
                );

            CreateMap<User, DriverViewModel>();
            CreateMap<User, ContactUserViewModel>();
        }
    }

    public static class UserMappingSupport
    {
        private static Account? GetAccount(this List<Account> accounts, RegistrationTypes type)
            => accounts.Where(acc => acc.RegistrationType == type).FirstOrDefault();
        public static string? GetRegistration(this List<Account> accounts, RegistrationTypes type)
            => accounts.GetAccount(type)?.Registration;
        public static bool? CheckVerifyAccount(this List<Account> accounts, RegistrationTypes type)
            => accounts.GetAccount(type)?.Verified;
        public static string? GetRoleName(this Role role)
            => role?.Name;
        public static string? GetFilePath(this AppFile? file, IAppServices? appServices)
        {
            if (file == null) return null;
            return appServices?.File.GetPresignedUrl(file.Path);
        }

        public static Guid? GetFileCode(this AppFile? file)
            => file?.Code;
    }
}