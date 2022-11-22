namespace API.Models.Requests
{
    public class SearchReportRequest
    {
        public string SearchValue { get; set; } = string.Empty;
        public PagingRequest? Paging { get; set; }
    }
}
