using API.Extensions;
using API.Models.Settings;
using API.Services.Constract;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace API.Services
{
    public class TokenService : BaseService, ITokenService
    {
        public TokenService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<bool> IsCurrentRevokedAccessToken()
            => await Cache.GetStringAsync(GetAccessTokenKey(GetCurrentAccessToken())) != null;

        public async Task RevokeCurrentAccessTokenAsync()
            => await Cache.SetStringAsync(GetAccessTokenKey(GetCurrentAccessToken()),
                " ", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromMinutes(Configuration.Get<double>(JwtSettings.AccessTokenTTLMinutes))
                });

        public async Task<bool> IsRevokedRefreshTokenAsync(string token)
            => await Cache.GetStringAsync(GetRefreshTokenKey(token)) != null;

        public async Task RevokeRefreshTokenAsync(string token)
        {
            await Cache.SetStringAsync(GetRefreshTokenKey(token),
                  " ", new DistributedCacheEntryOptions
                  {
                      AbsoluteExpirationRelativeToNow =
                          TimeSpan.FromDays(Configuration.Get<double>(JwtSettings.RefreshTokenTTLDays))
                  });

            await Cache.RemoveAsync(GetRefreshTokenKey(token, false));
        }

        private string GetCurrentAccessToken()
        {
            var authorizationHeader = Context.HttpContext.Request.Headers["authorization"];

            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(" ").Last();
        }

        public string GetRefreshTokenKey(string token, bool revoke = true)
            => $"refresh_tokens:{token}:{(revoke ? "revoked" : "active")}";

        public async Task CreateRefreshTokenAsync(string token, string userCode)
        => await Cache.SetStringAsync(GetRefreshTokenKey(token, false),
                userCode, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromDays(Configuration.Get<double>(JwtSettings.RefreshTokenTTLDays))
                });

        private static string GetAccessTokenKey(string token)
            => $"access_tokens:{token}:revoked";

        public async Task<string> ValueOfActiveRefreshToken(string token)
        => await Cache.GetStringAsync(GetRefreshTokenKey(token, false));
    }
}
