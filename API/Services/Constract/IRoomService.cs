using API.Models;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IRoomService
    {
        Task<Room> Create(MessageRoomTypes type);
        Task<Room> GetByCode(Guid roomCode);
        Task<MessageRoomViewModel> GetViewModelByCode (Guid roomCode);
        MessageRoomViewModel GetViewModelByMemberCode (List<Guid> memberCode);
        Task<List<MessageRoomViewModel>> GetByType (int userId, MessageRoomTypes type);
    }
}
