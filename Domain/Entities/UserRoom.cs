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
        public Rooms.UserRoomStatus Status { get; set; } = Rooms.UserRoomStatus.Active;
        public DateTimeOffset LastSeenTime { get; set; } = DateTimeOffset.Now;

        public User User { get; set; }
        public Room Room { get; set; }
    }
}
