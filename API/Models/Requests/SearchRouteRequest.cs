
namespace API.Models.Requests
{
    public class SearchRouteRequest
    {
        public string SearchValue { get; set; } = string.Empty;
        public PagingRequest? Paging { get; set; }
    }
}
