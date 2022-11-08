using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Responses;
using FirebaseAdmin.Messaging;

namespace API.Services.Constract
{
    public interface INotificationService
    {
        Task<Domain.Entities.Notification> PushNotificationSignalR(NotificationDTO dto, bool save = true);
        Task<string> SendPushNotification(NotificationDTO dto, bool isSave = false);
        Task<string> SendPushNotification(Message message);

        void SendPushNotifications(NotificationDTO dto, Dictionary<int, string> userInfos, bool isSave = false);

        PagingViewModel<IQueryable<NotificationViewModel>>? GetNotificationsOfUser(int userId, PagingRequest pagingRequest, DateFilterRequest dateFilterRequest);
    }
}
