using API.Models;

namespace API.JwtFeatures
{
    public interface IJwtHandler
    {
        string GenerateToken(UserViewModel user);
    }
}
