namespace API.Models.Requests
{
    public class DumpTripRequest
    {
        public int DriverId { get; set; }
        public List<int> UserIds { get; set; } = new();
    }
}
