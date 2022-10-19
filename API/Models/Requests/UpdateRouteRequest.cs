namespace API.Models.Requests
{
    public class UpdateRouteRequest
    {
        public string RouteCode { get; set; }
        public List<Guid> StationCodes { get; set; } = new();
    }
}
