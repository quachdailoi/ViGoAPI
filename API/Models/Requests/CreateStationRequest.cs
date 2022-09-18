namespace API.Models.Requests
{
    public class CreateStationRequest
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Province { get; set; } = String.Empty;
        public string District { get; set; } = String.Empty;
        public string Ward { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
    }
}
