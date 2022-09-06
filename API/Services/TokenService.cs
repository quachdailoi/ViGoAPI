﻿using API.Extensions;
using API.Models.Settings;
using API.Services.Constract;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        public TokenService(IDistributedCache cache,
                IHttpContextAccessor httpContextAccessor,
                IConfiguration configuration)
        {
            _config = configuration;
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> IsCurrentRevokedAccessToken()
            => await _cache.GetStringAsync(GetAccessTokenKey(GetCurrentAccessToken())) != null;

        public async Task RevokeCurrentAccessTokenAsync()
            => await _cache.SetStringAsync(GetAccessTokenKey(GetCurrentAccessToken()),
                " ", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromMinutes(_config.Get<double>(JwtSettings.AccessTokenTTLMinutes))
                });

        public async Task<bool> IsRevokedRefreshTokenAsync(string token)
            => await _cache.GetStringAsync(GetRefreshTokenKey(token)) != null;

        public async Task RevokeRefreshTokenAsync(string token)
        {
            await _cache.SetStringAsync(GetRefreshTokenKey(token),
                  " ", new DistributedCacheEntryOptions
                  {
                      AbsoluteExpirationRelativeToNow =
                          TimeSpan.FromDays(_config.Get<double>(JwtSettings.RefreshTokenTTLDays))
                  });

            await _cache.RemoveAsync(GetRefreshTokenKey(token, false));
        }

        private string GetCurrentAccessToken()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["authorization"];

            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(" ").Last();
        }

        public string GetRefreshTokenKey(string token, bool revoke = true)
            => $"refresh_tokens:{token}:{(revoke ? "revoked" : "active")}";

        public async Task CreateRefreshTokenAsync(string token, string userCode)
        => await _cache.SetStringAsync(GetRefreshTokenKey(token, false),
                userCode, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromDays(_config.Get<double>(JwtSettings.RefreshTokenTTLDays))
                });

        private static string GetAccessTokenKey(string token)
            => $"access_tokens:{token}:revoked";

        public async Task<string> ValueOfActiveRefreshToken(string token)
        => await _cache.GetStringAsync(GetRefreshTokenKey(token, false));
    }
}
