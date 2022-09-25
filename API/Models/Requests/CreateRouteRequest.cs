namespace API.Models.Requests
{
    public class CreateRouteRequest
    {
        public List<Guid> StationCodes { get; set; } = new();
    }
}
