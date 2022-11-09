using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Responses;
using FirebaseAdmin.Messaging;

namespace API.Services.Constract
{
    public interface INotificationService
    {
        Task<Domain.Entities.Notification> PushNotificationSignalR(NotificationDTO dto);
        Task SendPushNotification(NotificationDTO dto, bool isSave = true);
        Task<string> SendPushNotification(Message message);

        Task SendPushNotifications(NotificationDTO dto, Dictionary<int, string> userInfos, bool isSave = true);

        PagingViewModel<IQueryable<NotificationViewModel>>? GetNotificationsOfUser(int userId, PagingRequest pagingRequest, DateFilterRequest dateFilterRequest);
    }
}
