namespace API.Models
{
    public class NotificationViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public object? Data { get; set; }
    }
}
