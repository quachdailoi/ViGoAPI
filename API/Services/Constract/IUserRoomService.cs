

using API.Models.DTO;
using API.Models.Response;

namespace API.Services.Constract
{
    public interface IUserRoomService
    {
        Task<bool> UpdateLastSeenTime(int userId, Guid roomCode, DateTimeOffset now);
        Task<Response> UpdateLastSeenTime(UserDTO user, Guid roomCode, Response successResponse, Response errorResponse);

    }
}
