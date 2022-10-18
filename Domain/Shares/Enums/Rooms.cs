using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Rooms
    {
        public enum RoomTypes
        {
            Support,
            Conversation
        }

        public enum Status
        {
            Inactive,
            Active
        }

        public enum UserRoomStatus
        {
            Inactive,
            Active
        }

        public enum MessageStatus
        {
            Inactive,
            Active,
            Deleted
        }
    }
}
