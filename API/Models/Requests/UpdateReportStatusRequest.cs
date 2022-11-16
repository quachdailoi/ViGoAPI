using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class UpdateReportStatusRequest
    {
        public Guid Code { get; set; }
        public Reports.Status Status { get; set; }
    }
}
