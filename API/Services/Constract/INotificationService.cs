using FirebaseAdmin.Messaging;

namespace API.Services.Constract
{
    public interface INotificationService
    {
        Task<string> SendPushNotification(Message message);
    }
}
