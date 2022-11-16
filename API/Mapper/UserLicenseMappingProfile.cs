using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class UserLicenseMappingProfile : Profile
    {
        public UserLicenseMappingProfile()
        {
            IAppServices? service = null;

            CreateMap<UserLicense, UserLicenseViewModel>()
                .ForMember(
                    dest => dest.FrontSideImage,
                    opt => opt.MapFrom(
                        src => service.File.GetPresignedUrl(src.FrontSideFile.Path)
                    )
                ).ForMember(
                    dest => dest.BackSideImage,
                    opt => opt.MapFrom(
                        src => service.File.GetPresignedUrl(src.BackSideFile.Path)
                    )
                ).ForMember(
                    dest => dest.LicenseType,
                    opt => opt.MapFrom(
                        src => src.LicenseType.Name
                    )
                );
        }
    }
}
