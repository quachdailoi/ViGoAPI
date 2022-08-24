

namespace API.Services.Constract
{
    public interface IUserRoomService
    {
        Task<bool> Create(int roomId, List<int> userIds);
        //Task<Guid> GetRoomCodeByMemberCode(List<Guid> userCodes);

        Task<DateTime?> UpdateLastSeenTime(int userId, Guid roomCode);

    }
}
