using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class SettingMappingProfile : Profile
    {
        public SettingMappingProfile()
        {
            IAppServices? service = null;

            CreateMap<Setting, SettingInProfileViewModel>()
                .ForMember(
                    des => des.DataType,
                    opt => opt.MapFrom(src => service.Setting.GetDataTypeById(src.Id).Id)
                )
                .ForMember(
                    des => des.DataTypeName,
                    opt => opt.MapFrom(src => service.Setting.GetDataTypeById(src.Id).Name)
                )
                .ForMember(
                    des => des.Unit, 
                    opt => opt.MapFrom(src => service.Setting.GetDataUnitById(src.Id).Name)
                );
        }
    }
}
