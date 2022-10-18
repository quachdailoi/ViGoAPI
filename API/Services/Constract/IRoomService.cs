using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IRoomService
    {
        Task<Room> Create(List<Guid> userCodes, Rooms.RoomTypes type, MessageDTO? initMessage = null);
        Task<Response> Create(List<Guid> userCodes, Rooms.RoomTypes type, Response successResponse, Response duplicateResponse, Response errorResponse, MessageDTO? initMessage = null);
        Task<Room?> Disable(Guid roomCode);
        Task<MessageRoomViewModel?> GetViewModelByCode(Guid roomCode);
        Task<Response> GetViewModelByCode (int userId, Guid roomCode, Response successResponse);
        Task<Response> Get(int userId, GetMessageRoomRequest request, Response successResponse);
        Task<Room?> GetByMemberCode(List<Guid> memberCode);

    }
}
