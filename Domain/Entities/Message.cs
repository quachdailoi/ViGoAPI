﻿using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public Rooms.MessageStatus Status { get; set; } = Rooms.MessageStatus.Active;

        public int RoomId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Room Room { get; set; }
    }
}
