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
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoomService _roomService;
        private readonly ISignalRService _signalRService;
        private readonly IUserRoomService _userRoomService;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper, IRoomService roomService, ISignalRService signalRService, IUserRoomService userRoomService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roomService = roomService;
            _signalRService = signalRService;
            _userRoomService = userRoomService;
        }
        public async Task<Response> Create(string content, Guid roomCode, int userId, Response successResponse, Response errorResponse)
        {
            var room = await _roomService.GetViewModelByCode(roomCode);

            var message = new Message
            {
                RoomId = room.Id,
                UserId = userId,
                Content = content
            };

            await _unitOfWork.CreateTransactionAsync(); //open transaction

            message = await _unitOfWork.Messages.Add(message);

            //update Last seen time
            var result = await _userRoomService.UpdateLastSeenTime(userId, roomCode, DateTimeOffset.Now);

            if(message == null || !result)
            {
                await _unitOfWork.Rollback(); //roll back
                return errorResponse;
            }

            await _unitOfWork.CommitAsync();// commit


            if (message == null) return errorResponse;

            var messageViewModel = GetViewModel(message);

            var userCodes = room.Users.Select(user => user.Code.ToString()).ToList();

            await _signalRService.SendToUsersAsync(
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
            return _unitOfWork.Messages.List(msg => msg.Id == message.Id).MapTo<MessageViewModel>(_mapper).FirstOrDefault();
        }
    }
}
