using API.Models.DTO;
using FirebaseAdmin.Messaging;

namespace API.Services.Constract
{
    public interface INotificationService
    {
        Task<string> SendPushNotification(Message message);
        Task<Domain.Entities.Notification> PushNotification(NotificationDTO dto, bool save = true);
    }
}
