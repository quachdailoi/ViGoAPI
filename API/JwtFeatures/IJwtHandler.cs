using API.Models;
using Domain.Entities;
using Domain.Shares.Enums;
using System.Security.Claims;

namespace API.JwtFeatures
{
    public interface IJwtHandler
    {
        string GenerateToken(UserViewModel user, bool isExpired = true, string? otp = null, OtpTypes? otpType = null);
        Task<string> GenerateRefreshToken(string userCode);
        IQueryable<User>? GetUserByToken(string token);

        UserViewModel? GetUserViewModelByToken(string token);
        Task<UserViewModel?> GetUserViewModelByTokenAsync(string token);
        Tuple<string, OtpTypes>? GetOtpAndTypeFromToken(string? token);
    }
}
