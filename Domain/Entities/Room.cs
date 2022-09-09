﻿using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public StatusTypes.Room Status { get; set; } = StatusTypes.Room.Active;
        public MessageRoomTypes Type { get; set; } = MessageRoomTypes.Conversation;
        public String Name { get; set; } = String.Empty;

        public List<UserRoom> UserRooms { get; set; } = new();
        public List<Message> Messages { get; set; } = new();
        public BookingDetail? Booking { get; set; }
    }
}
