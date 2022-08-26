using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class MessageDTO : BaseDTO
    { 
        public string Content { get; set; } = string.Empty;
        public StatusTypes.Message Status { get; set; } = StatusTypes.Message.Active;

        public int RoomId { get; set; }
        public int UserId { get; set; }

    }
}
