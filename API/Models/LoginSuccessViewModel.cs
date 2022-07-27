namespace API.Models
{
    public class LoginSuccessViewModel
    {
        public string AccessToken { get; set; }
        public UserViewModel User { get; set; }
    }
}
