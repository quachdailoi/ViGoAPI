using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class NotificationDTO : BaseDTO
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Description { get; set; } = string.Empty;
        public Notifications.Types Type { get; set; }
        public object? Data { get; set; } = null;
        public Notifications.Status Status { get; set; } = Notifications.Status.Active;
        public int? UserId { get; set; } = null;
        public Events.Types EventId { get; set; }
    }
}
