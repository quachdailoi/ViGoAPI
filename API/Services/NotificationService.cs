using API.Models.DTO;
using API.Services.Constract;
using Domain.Shares.Enums;
using FirebaseAdmin.Messaging;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class NotificationService : BaseService, INotificationService
    {
        public NotificationService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<Domain.Entities.Notification> PushNotification(NotificationDTO dto, bool save = true)
        {
            var notification = Mapper.Map<Domain.Entities.Notification>(dto);
            if(save) notification = await UnitOfWork.Notifications.Add(notification);

            switch (notification.Type)
            {
                case Notifications.Types.SpecificUser:
                    var user = await AppServices.User.GetUserById(notification.UserId)?.FirstOrDefaultAsync();
                    if (user != null)
                        await AppServices.SignalR.SendToUserAsync(user.Code.ToString(), "Notifications", notification);
                    break;
                case Notifications.Types.Booker:
                    await AppServices.SignalR.SendToUsersGroupRoleNameAsync(Roles.BOOKER, "Notifications", notification);
                    break;
                case Notifications.Types.Driver:
                    await AppServices.SignalR.SendToUsersGroupRoleNameAsync(Roles.DRIVER, "Notifications", notification);
                    break;
                case Notifications.Types.Admin:
                    await AppServices.SignalR.SendToUsersGroupRoleNameAsync(Roles.ADMIN, "Notifications", notification);
                    break;
                case Notifications.Types.BookerAndDriver:
                    await AppServices.SignalR.SendToUsersGroupRoleNameAsync(Roles.BOOKER, "Notifications", notification);
                    await AppServices.SignalR.SendToUsersGroupRoleNameAsync(Roles.DRIVER, "Notifications", notification);
                    break;
                default:
                    break;
            }

            return notification;
        }

        public Task<string> SendPushNotification(Message message)
        {
            return FirebaseMessaging.DefaultInstance.SendAsync(message);
        }

        public void SendPushNotifications(Message message, List<string> fcmTokens)
        {
            fcmTokens.ForEach(x =>
            {
                message.Token = x;

                FirebaseMessaging.DefaultInstance.SendAsync(message);
            });
        }
    }
}
