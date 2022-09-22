using API.Models;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IUserService
    {
        Task<bool> UpdateUser(User user);
        IQueryable<User>? GetUserById(int? id);
        Task<UserViewModel?> GetUserViewModelById(int? userId);
        List<User> GetUsersByCode(List<Guid> userCodes);
        Task<Response> UpdateUserAvatar(string userCode, IFormFile avatar, Response successResponse, Response errorResponse);

        Task<Response> GetEmailWithFireBaseAuthAsync(LoginByEmailRequest request);
    }
}
