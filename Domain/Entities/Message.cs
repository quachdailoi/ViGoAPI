using Domain.Entities.Base;
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
        public StatusTypes.Message Status { get; set; } = StatusTypes.Message.Active;

        public int RoomId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; } = new();
        public Room Room { get; set; } = new();
    }
}
