using API.Services.Constract;
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

        public UserRoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Create(int roomId, List<int> userIds)
        {
            var listUserRoom = new List<UserRoom>();
            userIds.ForEach(userId =>
            {
                listUserRoom.Add(new UserRoom
                {
                    RoomId = roomId,
                    UserId = userId
                });
            });

            return await _unitOfWork.UserRooms.Add(listUserRoom) != null;
        }

        public async Task<Guid> GetRoomCodeByMemberCode(List<Guid> userCodes)
        {
            var userCodesHashSet = userCodes.ToHashSet();
            var userRoomIQueryable = _unitOfWork.UserRooms
                .List(userRoom => userCodesHashSet.Contains(userRoom.User.Code) && userRoom.Status == StatusTypes.UserRoom.Active)
                .Include(userRoom => userRoom.Room);

            var roomCode = userRoomIQueryable
                .AsEnumerable()
                .GroupBy(userRoom => userRoom.Room.Code)
                .Select(key => key.Key)
                .ToList()
                .First();

            return roomCode;
        }

        public async Task<bool> UpdateLastSeenTime(int userId, int roomId)
        {
            var userRoom = _unitOfWork.UserRooms
                                .List(userRoom => userRoom.UserId == userId && userRoom.RoomId == roomId && userRoom.Status == StatusTypes.UserRoom.Active)
                                .FirstOrDefault();
            userRoom.LastSeenTime = DateTime.UtcNow;

            return await _unitOfWork.UserRooms.Update(userRoom);
        }
    }
}
