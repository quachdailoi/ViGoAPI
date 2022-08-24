

namespace API.Services.Constract
{
    public interface IUserRoomService
    {
        Task<DateTime?> UpdateLastSeenTime(int userId, Guid roomCode);

    }
}
