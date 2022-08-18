using API.Models;
using Domain.Entities;
using System.Security.Claims;

namespace API.JwtFeatures
{
    public interface IJwtHandler
    {
        string GenerateToken(UserViewModel user, string? ipAddress = null);
        Task<string> GenerateRefreshToken(string userCode);
        IQueryable<User>? GetUserByToken(string token);

        Task<UserViewModel?> GetUserViewModelByToken(string token);
    }
}
