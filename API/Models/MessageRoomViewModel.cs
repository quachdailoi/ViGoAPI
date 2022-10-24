using API.Extensions;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class MessageRoomViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public Guid Code { get; set; }
        public List<MessageUserViewModel> Users { get; set; } = new();
        public List<MessageViewModel> Messages { get; set; } = new();
        public Rooms.Status Status { get; set; } 
        public string StatusName { get => Status.DisplayName(); }
        public Rooms.RoomTypes Type { get; set; }
        public string TypeName { get => Type.DisplayName(); }
    }
    public class MessageViewModel
    {
        public string Content { get; set; } = string.Empty;
        public string Time { get; set; }
        public Rooms.MessageStatus Status { get; set; }
        public string StatusName { get => Status.DisplayName(); }
        public Guid UserCode { get; set; }
    }
}
