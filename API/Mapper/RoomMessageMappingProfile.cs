﻿using API.Models;
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
                    dest => dest.UserCode,
                    opt => opt.MapFrom(
                            message => message.User.Code
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
                .ForMember(
                    dest => dest.Users,
                    opt => opt.MapFrom(
                            room => room.UserRooms.Select(user_room => user_room.User)
                        )
                    );
        }
    }
}
