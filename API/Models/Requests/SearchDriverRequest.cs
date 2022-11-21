using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class SearchDriverRequest
    {
        public string SearchValue { get; set; } = string.Empty;
        public Users.Status Status { get; set; }
        public PagingRequest Paging { get; set; }
    }
}
