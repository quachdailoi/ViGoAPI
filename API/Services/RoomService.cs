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

        //private IQueryable<Room> GetRoomByUserMembers(List<Guid> userCodes)
        //{
        //    var userCodeHashSet = userCodes.ToHashSet();
        //    var room = _unitOfWork.Rooms
        //        .List()
        //        .Selectroom => room.UserRooms
        //            .Where(userRoom => 
        //                userCodeHashSet.Contains(userRoom.User.Code) 
        //                && userRoom.Status == StatusTypes.UserRoom.Active)
        //            .GroupBy(userRoom => userRoom.RoomId)
        //            .FirstOrDefault()
        //            .
        //        );
        //    return null;
        //}
        public async Task<MessageRoomViewModel> GetViewModelByCode(Guid roomCode)
        {
            var rooms = _unitOfWork.Rooms.List(room => room.Code == roomCode);

            return await rooms.MapTo<MessageRoomViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<List<MessageRoomViewModel>> GetByType(int userId, MessageRoomTypes type)
        {
            var rooms = _unitOfWork.Rooms.List(room => room.UserRooms.Exists(userRoom => userRoom.UserId == userId) && room.Type == type);

            return await rooms.MapTo<MessageRoomViewModel>(_mapper).ToListAsync();
        }

        //public Task<bool> SendMessage(string userCode, string message)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
