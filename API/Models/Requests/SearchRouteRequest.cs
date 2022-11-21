
namespace API.Models.Requests
{
    public class SearchRouteRequest
    {
        public string SearchValue { get; set; }
        public PagingRequest Paging { get; set; }
    }
}
