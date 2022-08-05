using API.Models;

namespace API.JwtFeatures
{
    public interface IJwtHandler
    {
        string GenerateToken(UserViewModel user);
        string GenerateRefreshToken(UserViewModel user);
        UserViewModel GetUserFromToken(string token);
        Task<UserViewModel> ValidateToken(string token, bool validateLifeTime = true);
    }
}
