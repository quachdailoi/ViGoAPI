using API.Models; 
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.JwtFeatures
{
    public class JwtHandler : IJwtHandler
    {
		private readonly IConfiguration configuration;
		public JwtHandler(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		private SigningCredentials GetSigningCredentials()
		{
			var secretKeyBytes = Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value);

			var secretKey = new SymmetricSecurityKey(secretKeyBytes);

			return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);
		}

		private List<Claim> GetClaims(UserViewModel user)
		{
			var claims = new List<Claim>
			{
                //new Claim(ClaimTypes.Sid, user.Code.ToString()),
                //new Claim(ClaimTypes.Name, user.Name),
                //new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString()),
                new Claim("User", Newtonsoft.Json.JsonConvert.SerializeObject(user)),
				new Claim(ClaimTypes.Role, user.RoleName)
			};

			if (!string.IsNullOrEmpty(user.Email))
            {
				claims.Add(new Claim(ClaimTypes.Email, user.Email));
            }

			if (!string.IsNullOrEmpty(user.PhoneNumber))
            {
				claims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
            }

			return claims;
		}

		private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var tokenOptions = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddMinutes(60),
				signingCredentials: signingCredentials,
				issuer: configuration.GetSection("Jwt:Issuer").Value,
				audience: configuration.GetSection("Jwt:Audience").Value,
				notBefore: DateTime.Now
			);

			return tokenOptions;
		}

		private JwtSecurityToken GenerateRefreshTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var tokenOptions = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddMinutes(60),
				signingCredentials: signingCredentials,
				issuer: configuration.GetSection("Jwt:Issuer").Value,
				audience: configuration.GetSection("Jwt:Audience").Value,
				notBefore: DateTime.Now
			);

			return tokenOptions;
		}

		public string GenerateToken(UserViewModel user)
		{
			var signingCredentials = GetSigningCredentials();
			var claims = GetClaims(user);
			var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
			var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

			return token;
		}

		public string GenerateRefreshToken(UserViewModel user)
		{
			var signingCredentials = GetSigningCredentials();
			var claims = GetClaims(user);
			var tokenOptions = GenerateRefreshTokenOptions(signingCredentials, claims);
			var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

			return token;
		}
		public async Task<UserViewModel> ValidateToken(string token, bool validateLifeTime = true)
        {
			var secretKeyBytes = Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value);

			var secretKey = new SymmetricSecurityKey(secretKeyBytes);

			var tokenValidationResult = await new JwtSecurityTokenHandler().ValidateTokenAsync
				(
					token, 
					new TokenValidationParameters() 
					{ 
						ValidateLifetime = validateLifeTime,
						ValidateAudience = false,
						ValidateIssuer = false,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = secretKey
					}
				);
			
            if (!tokenValidationResult.IsValid)
            {

				if (tokenValidationResult.Exception.GetType().IsAssignableFrom(typeof(SecurityTokenExpiredException)))
                {
					throw new SecurityTokenExpiredException("Token is expired");
				}
				else
                {
					throw new SecurityTokenException("Token is invalid");
				}
            }
			return Newtonsoft.Json.JsonConvert.DeserializeObject<UserViewModel>((string)tokenValidationResult.Claims["User"]);
        }
		public UserViewModel GetUserFromToken (string token)
        {
			var claim = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.FirstOrDefault(x => x.Type == "User").Value;
			return Newtonsoft.Json.JsonConvert.DeserializeObject<UserViewModel>(claim);
        }
	}
}
