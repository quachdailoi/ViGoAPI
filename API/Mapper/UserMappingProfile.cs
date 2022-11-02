using API.Extensions;
using API.Mapper.MappingSupports;
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
                    opt => opt.MapFrom(src => src.Gmail)
                )
                .ForMember(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => src.PhoneNumber)
                )
                .ForMember(
                    dest => dest.RoleName,
                    opt => opt.MapFrom(src => src.RoleName)
                )
                .ForMember(
                    dest => dest.HasVerifiedGmail,
                    opt => opt.MapFrom(src => src.IsVerifiedGmail)
                )
                .ForMember(
                    dest => dest.HasVerifiedPhoneNumber,
                    opt => opt.MapFrom(src => src.IsVerifiedPhoneNumber)
                )
                .ForMember(
                    dest => dest.AvatarUrl,
                    opt => opt.MapFrom(src => src.File.GetFilePath(service))
                )
                .ForMember(
                    dest => dest.AvatarCode,
                    opt => opt.MapFrom(src => src.File.Code)
                );

            CreateMap<User, DriverViewModel>()
                .ForMember(
                    dest => dest.AvatarUrl,
                    otp => otp.MapFrom(src => src.File.GetFilePath(service)))
                .ForMember(
                    dest => dest.AvatarCode,
                    opt => opt.MapFrom(src => src.File.Code));

            CreateMap<User, DriverInBookingDetailViewModel>()
                .ForMember(
                    dest => dest.TripStatus,
                    opt => opt.Ignore())
                .IncludeBase<User, DriverViewModel>();

            CreateMap<User, ContactUserViewModel>()
                .ForMember(
                    dest => dest.AvatarUrl,
                    otp => otp.MapFrom(src => src.File.GetFilePath(service)))
                .ForMember(
                    dest => dest.AvatarCode,
                    opt => opt.MapFrom(src => src.File.Code));

            CreateMap<User, MessageUserViewModel>()
                .ForMember(
                    dest => dest.LastSeenTime,
                    opt => opt.MapFrom(
                            user => user.UserRooms.First().LastSeenTime.ToFormatString()))
                .ForMember(
                    dest => dest.AvatarUrl,
                    opt => opt.MapFrom(src => src.File.GetFilePath(service))
                )
                .ForMember(
                    dest => dest.AvatarCode,
                    opt => opt.MapFrom(src => src.File.Code)
                );
        }
    }
}