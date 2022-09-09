using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRoom : BaseEntity
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public StatusTypes.UserRoom Status { get; set; } = StatusTypes.UserRoom.Active;
        public DateTime LastSeenTime { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = new();
        public Room Room { get; set; } = new();  
    }
}
