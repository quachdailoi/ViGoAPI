namespace API.Models.Requests
{
    public class SearchStationRequest
    {
        public string SearchValue { get; set; } = string.Empty;
        public PagingRequest Paging { get; set; }
    }
}
