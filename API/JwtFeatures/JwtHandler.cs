using API.Models;
using API.Models.Settings;
using API.Services.Constract;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.JwtFeatures
{
    public class JwtHandler : IJwtHandler
    {
		private readonly IConfiguration _configuration;
        private readonly IAppServices _appservice;
        private readonly JwtSettings _jwtSettings;

		private readonly SigningCredentials _signingCredentials;

		public JwtHandler(IConfiguration configuration, IOptions<JwtSettings> jwtSettings, IAppServices appservice)
		{
			_configuration = configuration;
			_appservice = appservice;
            _jwtSettings = jwtSettings.Value;

			_signingCredentials = GetSigningCredentials();
		}

		private SigningCredentials GetSigningCredentials()
		{
			var secretKeyBytes = Encoding.UTF8.GetBytes(_jwtSettings.Key);

			var secretKey = new SymmetricSecurityKey(secretKeyBytes);

			return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);
		}

		private IDictionary<string, object> GetClaims(UserViewModel user, string? ipAddress = null)
		{
			IDictionary<string, object> claims = new Dictionary<string, object>();
			claims.Add(ClaimTypes.Name, user.Name);
			claims.Add(ClaimTypes.DateOfBirth, user.DateOfBirth);
			claims.Add(ClaimTypes.Role, user.RoleName);

			if (!string.IsNullOrEmpty(ipAddress))
            {
				claims.Add("ipAddress", ipAddress);
            }

			if (!string.IsNullOrEmpty(user.Gmail))
			{
				claims.Add(ClaimTypes.Email, user.Gmail);
			}

			if (!string.IsNullOrEmpty(user.PhoneNumber))
			{
				claims.Add(ClaimTypes.MobilePhone, user.PhoneNumber);
			}

			return claims;
		}

		private SecurityTokenDescriptor GenerateTokenDescriptor(UserViewModel user, string? ipAddress = null)
		{
			var tokenDescriptor = GenerateTokenDescriptor();

			tokenDescriptor.Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) });
			tokenDescriptor.Claims = GetClaims(user, ipAddress);

			return tokenDescriptor;
		}

		private IDictionary<string, object> ConvertEnumToDictionary(IEnumerable<Claim> claims)
		{
			IDictionary<string, object> claimDic = new Dictionary<string, object>();
			foreach (var claim in claims)
			{
				claimDic.Add(claim.Type, claim.Value);
			}

			return claimDic;
		}

		private SecurityTokenDescriptor GenerateTokenDescriptor(ClaimsPrincipal claimsPrincipal)
		{
			var claims = claimsPrincipal.Claims;

			var tokenDescriptor = GenerateTokenDescriptor();

			var userId = int.Parse(claims.First(x => x.Type == "id").Value);

			tokenDescriptor.Subject = new ClaimsIdentity(new[] { new Claim("id", userId.ToString()) });

			tokenDescriptor.Claims = ConvertEnumToDictionary(claims);

			return tokenDescriptor;
		}

		private SecurityTokenDescriptor GenerateTokenDescriptor()
		{
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				SigningCredentials = _signingCredentials,
				Issuer = _jwtSettings.Issuer,
				Audience = _jwtSettings.Audience,
				NotBefore = DateTime.UtcNow,
				Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenTTLMinutes),
			};

			return tokenDescriptor;
		}

		public string GenerateToken(UserViewModel user, string? ipAddress = null)
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			var tokenDescriptor = GenerateTokenDescriptor(user, ipAddress);

			var securityToken = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(securityToken);
		}

		public async Task<string> GenerateRefreshToken(string userCode)
		{
			var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
			await _appservice.Token.CreateRefreshTokenAsync(token, userCode);
			return token;
		}

		private int? GetUserIdFromToken(string token)
		{
			if (token == null)
			{
				return null;
			}
			
			try
			{
				GetPrincipal(token, out SecurityToken validatedToken);

				var jwtToken = (JwtSecurityToken)validatedToken;
				var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

				return userId;
			}
			catch
			{
				return null;
			}
		}

		public IQueryable<User>? GetUserByToken(string token)
        {
			var userId = GetUserIdFromToken(token);

			return _appservice.User.GetUserById(userId);
        }

		private ClaimsPrincipal GetPrincipal(string token, out SecurityToken validatedToken)
        {
			var tokenHandler = new JwtSecurityTokenHandler();
			var secretKeyBytes = Encoding.UTF8.GetBytes(_jwtSettings.Key);

			return tokenHandler.ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = _jwtSettings.Issuer,
				ValidateAudience = true,
				ValidAudience = _jwtSettings.Audience,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
				ClockSkew = TimeSpan.Zero
			}, out validatedToken);
		}

        public Task<UserViewModel?> GetUserViewModelByToken(string token)
        {
			var userId = GetUserIdFromToken(token);

			return _appservice.User.GetUserViewModelById(userId);
		}
    }
}
