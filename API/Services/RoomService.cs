using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
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
        private readonly IUserService _userService;
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<MessageRoomViewModel?> GetViewModelByCode(Guid roomCode)
        {
                var rooms = _unitOfWork.Rooms.GetRoomsByCode(roomCode);

                return await rooms.MapTo<MessageRoomViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<Response> GetViewModelByCode(int userId, Guid roomCode, Response successResponse)
        {
            var rooms = _unitOfWork.Rooms.GetRoomsByCode(roomCode)
                                         .Where(room => room.UserRooms.Select(userRoom => userRoom.UserId).Contains(userId) && 
                                                        room.Status == StatusTypes.Room.Active);

            var room = await rooms.MapTo<MessageRoomViewModel>(_mapper).FirstOrDefaultAsync();

            return successResponse.SetData(room);
        }

        public async Task<Response> GetByType(int userId, MessageRoomTypes type, Response successResponse)
        {
            var rooms = _unitOfWork.Rooms.List(room => room.UserRooms.Exists(userRoom => userRoom.UserId == userId) && room.Type == type);

            var roomViewModels = await rooms.MapTo<MessageRoomViewModel>(_mapper).ToListAsync();

            return successResponse.SetData(roomViewModels);
        }
        private IQueryable<Room> GetByMemberCode(List<Guid> memberCode)
        {
            var userCodeHashSet = memberCode.ToHashSet();

            var roomQueryable = _unitOfWork.Rooms
                                    .List(room => room.UserRooms
                                    .Select(userRoom => userRoom.User.Code)
                                    .All(userCode => userCodeHashSet.Contains(userCode)) &&
                                            room.UserRooms
                                            .Select(userRoom => userRoom.User.Code)
                                            .Count() == userCodeHashSet.Count &&
                                            room.Status == StatusTypes.Room.Active);

            return roomQueryable;
        }
        public Response GetViewModelByMemberCode(List<Guid> memberCode, Response successResponse)
        {
            var userCodeHashSet = memberCode.ToHashSet();

            var messageRoomViewModel = GetByMemberCode(memberCode).MapTo<MessageRoomViewModel>(_mapper).FirstOrDefault();
            

            return successResponse.SetData(messageRoomViewModel);
        }

        public async Task<Room?> GetByCode(Guid roomCode) => await _unitOfWork.Rooms.GetRoomsByCode(roomCode).FirstOrDefaultAsync();
        public async Task<Room> Create(List<Guid> userCodes, MessageRoomTypes type, MessageDTO? initMessage)
        {
            var userRooms = new List<UserRoom>();

            var users = _userService.GetUsersByCode(userCodes);

            users.ForEach(user =>
            {
                userRooms.Add(new UserRoom
                {
                    UserId = user.Id
                });
            });

            var room = new Room
            {
                Type = type,
                UserRooms = userRooms
            };

            if (initMessage != null)
            {
                room.Messages.Add(new Message
                {
                    Content = initMessage.Content,
                    UserId = initMessage.UserId
                });
            }

            return await _unitOfWork.Rooms.Add(room);
        }
        public async Task<Response> Create(List<Guid> userCodes, MessageRoomTypes type, Response successResponse, Response duplicateResponse, Response errorResponse, MessageDTO? initMessage = null)
        {
            if (GetByMemberCode(userCodes).Any())
            {
                return duplicateResponse;
            }

            var result = await Create(userCodes,type,initMessage);

            if (result == null)
            {
                return errorResponse;
            }

            var messageRoomViewModel = await GetViewModelByCode(result.Code);

            return successResponse.SetData(messageRoomViewModel);
        }

        public async Task<Room?> Disable(Guid roomCode)
        {
            var room = _unitOfWork.Rooms.List(room => room.Code == roomCode).FirstOrDefault();

            room.Status = StatusTypes.Room.InActive;

            return await _unitOfWork.Rooms.Update(room) ? room : null;
        }

        public async Task<Response> GetAll(int userId, Response successResponse)
        {
            var rooms = await _unitOfWork.Rooms.List(room => room.UserRooms
                                                            .Select(userRoom => userRoom.UserId).Contains(userId) && 
                                                            room.Status == StatusTypes.Room.Active)
                                                    .MapTo<MessageRoomViewModel>(_mapper)
                                                    .ToListAsync();

             return successResponse.SetData(rooms);
        }
    }
}
