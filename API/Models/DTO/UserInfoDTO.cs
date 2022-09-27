namespace API.Models.DTO
{
    public class UserInfoDTO
    {
    }

    public class MomoUserInfoDTO : UserInfoDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
