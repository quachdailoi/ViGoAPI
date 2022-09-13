namespace API.Models.DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public int UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
