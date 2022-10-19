using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<MessageRoomViewModel?> GetViewModelByCode(Guid roomCode)
        {
                var rooms = UnitOfWork.Rooms.GetRoomsByCode(roomCode);

                return await rooms.MapTo<MessageRoomViewModel>(Mapper,AppServices).FirstOrDefaultAsync();
        }
        public async Task<Response> GetViewModelByCode(int userId, Guid roomCode, Response successResponse)
        {
            var rooms = UnitOfWork.Rooms.GetRoomsByCode(roomCode)
                                         .Where(room => room.UserRooms.Select(userRoom => userRoom.UserId).Contains(userId) && 
                                                        room.Status == Rooms.Status.Active);

            var room = await rooms.MapTo<MessageRoomViewModel>(Mapper,AppServices).FirstOrDefaultAsync();

            return successResponse.SetData(room);
        }

        private IQueryable<Room> GetByMemberCodeQueryable(List<Guid> memberCode)
        {
            var userCodeHashSet = memberCode.ToHashSet();

            var roomQueryable = UnitOfWork.Rooms
                                    .List(room => room.UserRooms
                                    .Select(userRoom => userRoom.User.Code)
                                    .All(userCode => userCodeHashSet.Contains(userCode)) &&
                                            room.UserRooms
                                            .Select(userRoom => userRoom.User.Code)
                                            .Count() == userCodeHashSet.Count &&
                                            room.Status == Rooms.Status.Active)
                                    .Include(room => room.UserRooms);

            return roomQueryable;
        }

        public Task<Room?> GetByMemberCode(List<Guid> memberCode) => GetByMemberCodeQueryable(memberCode).FirstOrDefaultAsync();

        public async Task<Room> Create(List<Guid> userCodes, Rooms.RoomTypes type, MessageDTO? initMessage)
        {
            var userRooms = new List<UserRoom>();

            var users = AppServices.User.GetUsersByCode(userCodes);

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

            return await UnitOfWork.Rooms.Add(room);
        }
        public async Task<Response> Create(List<Guid> userCodes, Rooms.RoomTypes type, Response successResponse, Response duplicateResponse, Response errorResponse, MessageDTO? initMessage = null)
        {
            if (GetByMemberCodeQueryable(userCodes).Any())
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
            var room = UnitOfWork.Rooms.List(room => room.Code == roomCode).FirstOrDefault();

            if (room == null) return null;

            room.Status = Rooms.Status.Inactive;

            return await UnitOfWork.Rooms.Update(room) ? room : null;
        }

        public async Task<Response> Get(int userId, GetMessageRoomRequest request, Response successResponse)
        {
            var rooms = UnitOfWork.Rooms
                .List(room => room.UserRooms
                .Select(userRoom => userRoom.UserId)
                .Contains(userId) &&
                room.Status == Rooms.Status.Active);

            if (request.Code.HasValue)
            {
                rooms = rooms.Where(room => room.Code == request.Code.Value);
            }

            if (request.Type.HasValue)
            {
                rooms = rooms.Where(room => room.Type == request.Type.Value);
            }

            var roomVMs = await rooms
                .MapTo<MessageRoomViewModel>(Mapper,AppServices)
                .ToListAsync();

             return successResponse.SetData(roomVMs);
        }

        public async Task<Room?> GetRoomByCode(Guid roomCode)
        {
            return 
                await UnitOfWork.Rooms
                    .List(room => room.Code == roomCode && room.Status == Rooms.Status.Active)                                              
                    .Include(room => room.UserRooms)                                              
                    .ThenInclude(userRoom => userRoom.User)                                              
                    .FirstOrDefaultAsync();
        }
    }
}
