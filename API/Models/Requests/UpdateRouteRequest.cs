using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class UpdateRouteRequest
    {
        public string RouteName { get; set; }
        public string RouteCode { get; set; }
        public List<Guid> StationCodes { get; set; } = new();
        public Routes.Status Status { get; set; }
    }
}
