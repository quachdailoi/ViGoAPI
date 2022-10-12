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
    public class UserRoomService : BaseService, IUserRoomService
    {
        public UserRoomService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<Response> UpdateLastSeenTime(UserDTO user,Guid roomCode, Response successResponse, Response errorResponse)
        {
            var now = DateTimeOffset.Now;

            var result = await UpdateLastSeenTime(user.Id, roomCode, now);

            var room = await AppServices.Room.GetViewModelByCode(roomCode);

            var userCodes = room.Users.Select(user => user.Code.ToString()).ToList();

            await AppServices.SignalR.SendToUsersAsync(
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
            var userRoom = UnitOfWork.UserRooms
                                .List(userRoom => userRoom.UserId == userId && userRoom.Room.Code == roomCode && userRoom.Status == StatusTypes.UserRoom.Active)
                                .FirstOrDefault();

            if (userRoom == null) return false; 

            userRoom.LastSeenTime = now;

            return await UnitOfWork.UserRooms.Update(userRoom);
        }
    }
}
