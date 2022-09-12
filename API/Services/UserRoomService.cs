using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using API.SignalR.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserRoomService : IUserRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoomService _roomService;
        private readonly ISignalRService _signalRService;

        public UserRoomService(IUnitOfWork unitOfWork, IMapper mapper, IRoomService roomService, ISignalRService signalRService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roomService = roomService;
            _signalRService = signalRService;
        }

        public async Task<Response> UpdateLastSeenTime(UserDTO user,Guid roomCode, Response successResponse, Response errorResponse)
        {
            var now = DateTimeOffset.Now;

            var result = await UpdateLastSeenTime(user.Id, roomCode, now);

            var room = await _roomService.GetViewModelByCode(roomCode);

            var userCodes = room.Users.Select(user => user.Code.ToString()).ToList();

            await _signalRService.SendToUsersAsync(
                        userCodes,
                        "UpdateLastSeen",
                        new
                        {
                            RoomCode = roomCode,
                            UserCode = user.Code,
                            LastSeenTime = now
                        });

            return result ? successResponse.SetData(now) : errorResponse;
        }

        public async Task<bool> UpdateLastSeenTime(int userId, Guid roomCode, DateTimeOffset now)
        {
            var userRoom = _unitOfWork.UserRooms
                                .List(userRoom => userRoom.UserId == userId && userRoom.Room.Code == roomCode && userRoom.Status == StatusTypes.UserRoom.Active)
                                .FirstOrDefault();

            if (userRoom == null) return false; 

            userRoom.LastSeenTime = now;

            return await _unitOfWork.UserRooms.Update(userRoom);
        }
    }
}
