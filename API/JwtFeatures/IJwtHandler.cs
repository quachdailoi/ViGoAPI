using API.Models;
using Domain.Entities;
using System.Security.Claims;

namespace API.JwtFeatures
{
    public interface IJwtHandler
    {
        string GenerateToken(UserViewModel user, bool isExpired = true, string? ipAddress = null);
        Task<string> GenerateRefreshToken(string userCode);
        IQueryable<User>? GetUserByToken(string token);

        UserViewModel? GetUserViewModelByToken(string token);
        Task<UserViewModel?> GetUserViewModelByTokenAsync(string token);
    }
}
