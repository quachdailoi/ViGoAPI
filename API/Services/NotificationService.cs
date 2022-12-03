using API.Models.DTO;
using API.Services.Constract;
using Domain.Shares.Enums;
using FirebaseAdmin.Messaging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using API.Models.Requests;
using API.Models.Responses;
using API.Models;

namespace API.Services
{
    public class NotificationService : BaseService, INotificationService
    {
        public NotificationService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<Domain.Entities.Notification> PushNotificationSignalR(NotificationDTO dto)
        {
            var notification = Mapper.Map<Domain.Entities.Notification>(dto);

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

        public async Task SendPushNotification(NotificationDTO dto, bool isSave = true)
        {
            await PushNotificationSignalR(dto);

            var message = MapToNotiMessage(dto);

            if (isSave)
            {
                var notification = Mapper.Map<Domain.Entities.Notification>(dto);

                await UnitOfWork.Notifications.Add(notification);
            }

            FirebaseMessaging.DefaultInstance.SendAsync(message);
        }

        public Task<string> SendPushNotification(Message message)
        {
            return FirebaseMessaging.DefaultInstance.SendAsync(message);
        }

        public async Task SendPushNotifications(NotificationDTO dto, Dictionary<int, string> userInfos, bool isSave = true)
        {
            var message = MapToNotiMessage(dto);

            foreach(var info in userInfos)
            {
                message.Token = info.Value; // fcm token
                dto.UserId = info.Key;
                dto.Token = info.Value;
                await PushNotificationSignalR(dto); 

                try
                {
                    if (isSave)
                    {
                        Domain.Entities.Notification notification = new();
                        notification = Mapper.Map(dto, notification);
                        notification.Code = Guid.NewGuid();
                        await UnitOfWork.Notifications.Add(notification);
                    }
                    
                    await FirebaseMessaging.DefaultInstance.SendAsync(message);
                }
                catch (Exception ex)
                {
                    Logger<NotificationService>().LogError($"===> ERROR send push notification: {ex.Message}");
                }
            }
           
        }

        private Message MapToNotiMessage(NotificationDTO dto)
        {
            var eventDTO = UnitOfWork.Events.List(x => x.Id == dto.EventId).FirstOrDefault();

            if (eventDTO == null) throw new Exception("Not found event to send push notification.");

            var message = new FirebaseAdmin.Messaging.Message()
            {
                Data = Utilities.Utils.ToDictionary<string>(dto.Data),
                Token = dto.Token,
                Notification = new Notification()
                {
                    Title = eventDTO.Title,
                    Body = eventDTO.Content
                },
                Apns = new()
                {
                    Aps = new()
                    {
                        Sound = "notification.mp3"
                    }
                }
            };

            return message;
        } 

        public PagingViewModel<IQueryable<NotificationViewModel>>? GetNotificationsOfUser(int userId, PagingRequest pagingRequest, DateFilterRequest dateFilterRequest)
        {
            var notifications = UnitOfWork.Notifications.List(x => x.UserId == userId).OrderByDescending(x => x.CreatedAt);

            if (dateFilterRequest.FromDate != null && dateFilterRequest.ToDate != null)
                notifications = notifications.Where(x => dateFilterRequest.FromDateParsed().ToDateTime(TimeOnly.MinValue) <= x.CreatedAt.DateTime &&
                        x.CreatedAt.DateTime <= dateFilterRequest.ToDateParsed().ToDateTime(TimeOnly.MinValue)).OrderByDescending(x => x.CreatedAt); ;
                
            return notifications.PagingMap<Domain.Entities.Notification, NotificationViewModel>(Mapper, page: pagingRequest.Page, pageSize: pagingRequest.PageSize);
        }
    }
}
