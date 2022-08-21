using API.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class RoomMessageMappingProfile : Profile
    {
        public RoomMessageMappingProfile()
        {

            CreateMap<Message, MessageViewModel>()
                .ForMember(
                    dest => dest.User,
                    opt => opt.MapFrom(
                            message => message.User
                        )
                );
            CreateMap<User, MessageUserViewModel>()
                .ForMember(
                    dest => dest.LastSeenTime,
                    opt => opt.MapFrom(
                            user => user.UserRooms.First().LastSeenTime
                ))
                .IncludeBase<User,UserViewModel>();

            CreateMap<Room, MessageRoomViewModel>()
                //.ForMember(
                //    dest => dest.LastSeenTime,
                //    opt => opt.MapFrom(
                //            room => room.UserRooms.First().LastSeenTime
                //        )
                //    )
                .ForMember(
                    dest => dest.Users,
                    opt => opt.MapFrom(
                            room => room.UserRooms.Select(user_room => user_room.User)
                        )
                    );
                //.IncludeBase<User, UserViewModel>()
                //.IncludeBase<Message, MessageViewModel>();
        }
    }
}
