﻿using Domain.Shares.Enums;
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
        public StatusTypes.Room Status { get; set; } 
    }
    public class MessageViewModel
    {
        public string Content { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
        public StatusTypes.Message Status { get; set; }
        public Guid UserCode { get; set; }
    }

    public class MessageUserViewModel : UserViewModel
    {
        public DateTimeOffset LastSeenTime { get; set; }
    }
}
