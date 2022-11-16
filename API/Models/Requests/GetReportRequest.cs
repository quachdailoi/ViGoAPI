using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class GetReportRequest
    {
        public Reports.Status? Status { get; set; } = null;
    }
}
