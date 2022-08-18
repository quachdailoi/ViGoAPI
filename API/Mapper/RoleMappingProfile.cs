using API.Models;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, UserViewModel>()
                .ForMember(
                    model => model.RoleName,
                    config => config.MapFrom(
                        role => role.Name
                    )
                );
        }
    }
}
