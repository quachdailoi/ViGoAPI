namespace API.Models.Requests
{
    public class NotificationRequest
    {
        public string Token { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string>? Data { get; set; } = null;
    }
}
