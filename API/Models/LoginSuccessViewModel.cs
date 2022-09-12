namespace API.Models
{
    public class LoginSuccessViewModel
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTimeOffset AccessTokenExpiredTime { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTimeOffset RefreshTokenExpiredTime { get; set; }
        public UserViewModel User { get; set; } = new();
    }
}
