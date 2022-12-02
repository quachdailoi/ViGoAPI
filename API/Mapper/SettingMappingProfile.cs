using API.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class SettingMappingProfile : Profile
    {
        public SettingMappingProfile()
        {
            CreateMap<Setting, SettingInProfileViewModel>()
                .ForMember(
                    des => des.DataType,
                    opt => opt.MapFrom(src => src.Id.GetUnitAndDataType().Item1)
                )
                .ForMember(
                    des => des.DataTypeName,
                    opt => opt.MapFrom(src => src.Id.GetUnitAndDataType().Item1.ToString())
                )
                .ForMember(
                    des => des.Unit, 
                    opt => opt.MapFrom(src => src.Id.GetUnitAndDataType().Item2)
                );
        }
    }
}
