using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class MessageDTO : BaseDTO
    { 
        public string Content { get; set; } = string.Empty;
        public Rooms.MessageStatus Status { get; set; } = Rooms.MessageStatus.Active;

        public int RoomId { get; set; }
        public int UserId { get; set; }

    }
}
