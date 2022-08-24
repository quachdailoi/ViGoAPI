using API.Extensions;
using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Room> Create(MessageRoomTypes type)
        {
            var room = new Room
            {
                Type = type
            };
            return _unitOfWork.Rooms.Add(room);
        }

        public async Task<MessageRoomViewModel> GetViewModelByCode(Guid roomCode)
        {
            var rooms = _unitOfWork.Rooms.GetRoomsByCode(roomCode);

            return await rooms.MapTo<MessageRoomViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<List<MessageRoomViewModel>> GetByType(int userId, MessageRoomTypes type)
        {
            var rooms = _unitOfWork.Rooms.List(room => room.UserRooms.Exists(userRoom => userRoom.UserId == userId) && room.Type == type);

            return await rooms.MapTo<MessageRoomViewModel>(_mapper).ToListAsync();
        }

        public MessageRoomViewModel GetViewModelByMemberCode(List<Guid> memberCode)
        {
            var userCodeHashSet = memberCode.ToHashSet();

            var roomQueyable = _unitOfWork.Rooms
                .List(room => room.UserRooms
                                   .Select(userRoom => userRoom.User.Code)
                                   .All(userCode => userCodeHashSet.Contains(userCode)) &&
                              room.UserRooms
                                   .Select(userRoom => userRoom.User.Code)
                                   .Count() == userCodeHashSet.Count &&
                              room.Status == StatusTypes.Room.Active);

            return roomQueyable.MapTo<MessageRoomViewModel>(_mapper).FirstOrDefault();
        }

        public async Task<Room> GetByCode(Guid roomCode) => await _unitOfWork.Rooms.GetRoomsByCode(roomCode).FirstOrDefaultAsync();

        public Task<Room> Create(List<int> MemberIds, MessageRoomTypes type, Message? initMessage = null)
        {
            var userRooms = new List<UserRoom>();

            MemberIds.ForEach(memberId =>
            {
                userRooms.Add(new UserRoom
                {
                    UserId = memberId
                });
            });

            var room = new Room
            {
                Type = type,
                UserRooms = userRooms
            };

            if (initMessage != null)
            {
                room.Messages.Add(initMessage);
            }
            
            return _unitOfWork.Rooms.Add(room);
        }

        public async Task<Room?> Disable(Guid roomCode)
        {
            var room = _unitOfWork.Rooms.List(room => room.Code == roomCode).FirstOrDefault();

            room.Status = StatusTypes.Room.InActive;

            return await _unitOfWork.Rooms.Update(room) ? room : null;
        }
    }
}
