namespace API.Services.Constract
{
    public interface ITokenService
    {
        Task<bool> IsCurrentRevokedAccessToken();
        Task RevokeCurrentAccessTokenAsync();

        Task<bool> IsRevokedRefreshTokenAsync(string token);
        Task RevokeRefreshTokenAsync(string token);

        Task CreateRefreshTokenAsync(string token, string userCode);
        string GetRefreshTokenKey(string token, bool revoke = true);

        Task<string> ValueOfActiveRefreshToken(string token);
    }
}
