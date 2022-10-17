using Domain.Entities.Base;
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
        public Rooms.Status Status { get; set; } = Rooms.Status.Active;
        public Rooms.RoomTypes Type { get; set; } = Rooms.RoomTypes.Conversation;
        public string Name { get; set; } = String.Empty;

        public List<UserRoom> UserRooms { get; set; } = new();
        public List<Message> Messages { get; set; } = new();
        public List<BookingDetail> BookingDetails { get; set; } = new();
    }
}
