using API.Services.Constract;
using FirebaseAdmin.Messaging;

namespace API.Services
{
    public class NotificationService : BaseService, INotificationService
    {
        public NotificationService(IAppServices appServices) : base(appServices)
        {
        }

        public Task<string> SendPushNotification(Message message)
        {
            return FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}
