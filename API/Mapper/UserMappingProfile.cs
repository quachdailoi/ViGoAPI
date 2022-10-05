using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class UserMappingProfile : Profile
    {
        private readonly IFileService _fileService;

        public UserMappingProfile(IFileService fileService)
        {
            _fileService = fileService;

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
                    opt => opt.MapFrom(user => user.File == null ? null : _fileService.GetPresignedUrl(user.File.Path))
                )
                .ForMember(
                    dest => dest.AvatarCode,
                    opt => opt.MapFrom(user => user.File == null ? Guid.Empty : user.File.Code)
                );

            CreateMap<User, DriverViewModel>();
            CreateMap<User, ContactUserViewModel>();
        }
    }
}