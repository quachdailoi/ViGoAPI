using API.Models;
using API.Models.DTO;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<NotificationDTO, Notification>();

            CreateMap<Notification, NotificationViewModel>()
                .ForMember(
                    des => des.Title,
                    opt => opt.MapFrom(
                        src => src.Event.Title
                    )
                ).ForMember(
                    des => des.Content,
                    opt => opt.MapFrom(
                        src => src.Event.Content
                    )
                ).ForMember(
                    des => des.DateTime,
                    opt => opt.MapFrom(
                        src => src.CreatedAt
                    )
                ).ForMember(
                    des => des.Data,
                    opt => opt.MapFrom(
                        src => src.Data
                    )
                );
        }
    }
}
