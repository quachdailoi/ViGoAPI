using System.Text.Json.Serialization;

namespace API.Models.Requests
{
    public class PagingRequest
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
