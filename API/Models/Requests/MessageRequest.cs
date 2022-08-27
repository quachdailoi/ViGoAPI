namespace API.Models.Requests
{
    public class MessageRequest
    {
        public Guid RoomCode { get; set; }
        public string Content { get; set; }
    }
}
