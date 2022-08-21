

namespace API.Services.Constract
{
    public interface IUserRoomService
    {
        Task<bool> Create(int roomId, List<int> userIds);
        Task<Guid> GetRoomCodeByMemberCode(List<Guid> userCodes);

        Task<bool> UpdateLastSeenTime(int userId, int roomId);

    }
}
