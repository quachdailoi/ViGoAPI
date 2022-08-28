namespace API.Models.DTO
{
    public class UserDTO : BaseDTO
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Gender { get; set; }
        public int Status { get; set; } = 1;
        public DateTime DateOfBirth { get; set; }
        public int? FileId { get; set; }
    }
}
