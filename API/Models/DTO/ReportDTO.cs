using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class ReportDTO : BaseDTO
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public object? Data { get; set; } = null;
        public Reports.Types Type { get; set; }
        public Reports.Status Status { get; set; } = Reports.Status.Pending;
    }
}
