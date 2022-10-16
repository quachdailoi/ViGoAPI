using API.Models;
using API.Models.DTO;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IRoomService
    {
        Task<Room> Create(List<Guid> userCodes, Rooms.Types type, MessageDTO? initMessage = null);
        Task<Response> Create(List<Guid> userCodes, Rooms.Types type, Response successResponse, Response duplicateResponse, Response errorResponse, MessageDTO? initMessage = null);
        Task<Room?> Disable(Guid roomCode);
        Task<Room?> GetByCode(Guid roomCode);
        Task<MessageRoomViewModel?> GetViewModelByCode(Guid roomCode);
        Task<Room?> GetRoomByCode(Guid roomCode);
        Task<Response> GetViewModelByCode (int userId, Guid roomCode, Response successResponse);
        Response GetViewModelByMemberCode (List<Guid> memberCode, Response successResponse);
        Task<Response> GetByType (int userId, Rooms.Types type, Response successResponse);
        Task<Response> GetAll(int userId, Response successResponse);

    }
}
