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

        public async Task<DateTime?> UpdateLastSeenTime(int userId, Guid roomCode)
        {
            var userRoom = _unitOfWork.UserRooms
                                .List(userRoom => userRoom.UserId == userId && userRoom.Room.Code == roomCode && userRoom.Status == StatusTypes.UserRoom.Active)
                                .FirstOrDefault();
            userRoom.LastSeenTime = DateTime.UtcNow;

            var result = await _unitOfWork.UserRooms.Update(userRoom);

            return result ? userRoom.LastSeenTime : null;
        }
    }
}
