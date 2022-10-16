using API.Extensions;
using API.Models;
using API.Models.Response;
using API.Services.Constract;
using API.SignalR.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class MessageService : BaseService, IMessageService
    {
        public MessageService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<Response> Create(string content, Guid roomCode, UserViewModel user, Response successResponse, Response errorResponse)
        {
            var room = await AppServices.Room.GetViewModelByCode(roomCode);

            var message = new Message
            {
                RoomId = room.Id,
                UserId = user.Id,
                Content = content
            };

            await UnitOfWork.CreateTransactionAsync(); //open transaction

            //update Last seen time
            var result = await AppServices.UserRoom.UpdateLastSeenTime(user.Id, roomCode, DateTimeOffset.Now);

            if((await UnitOfWork.Messages.Add(message)) == null || !result)
            {
                await UnitOfWork.Rollback(); //roll back
                return errorResponse;
            }

            await UnitOfWork.CommitAsync();// commit

            message.User = new User { Code = user.Code };

            var messageViewModel = GetViewModel(message);

            var userCodes = room.Users.Select(user => user.Code.ToString()).ToList();

            await AppServices.SignalR.SendToUsersAsync(
                userCodes,
                "Message",
                new
                {
                    RoomCode = room.Code,
                    Message = messageViewModel
                });

            return successResponse.SetData(messageViewModel);
        }

        public MessageViewModel GetViewModel(Message message)
        {
            return Mapper.Map<MessageViewModel>(message);
        }
    }
}
