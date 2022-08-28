using API.Models;
using API.Models.DTO;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IRoomService
    {
        Task<Response> Create(List<Guid> userCodes, MessageRoomTypes type, Response successResponse, Response duplicateResponse, Response errorResponse, MessageDTO? initMessage = null);
        Task<Room?> Disable(Guid roomCode);
        Task<Room?> GetByCode(Guid roomCode);
        Task<MessageRoomViewModel> GetViewModelByCode(Guid roomCode);
        Task<Response> GetViewModelByCode (Guid roomCode, Response successResponse, Response notFoundResponse, Response errorResponse);
        Response GetViewModelByMemberCode (List<Guid> memberCode, Response successResponse, Response notFoundResponse, Response errorResponse);
        Task<Response> GetByType (int userId, MessageRoomTypes type, Response successResponse, Response notFoundResponse, Response errorResponse);
    }
}
