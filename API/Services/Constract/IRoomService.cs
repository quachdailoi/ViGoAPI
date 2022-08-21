using API.Models;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IRoomService
    {
        Task<Room> Create(MessageRoomTypes type);
        Task<MessageRoomViewModel> GetViewModelByCode (Guid roomCode);
        Task<List<MessageRoomViewModel>> GetByType (int userId, MessageRoomTypes type);
    }
}
