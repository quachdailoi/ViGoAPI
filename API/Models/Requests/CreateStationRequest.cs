namespace API.Models.Requests
{
    public class CreateStationRequest
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = String.Empty;
    }
    public class CreateStationRequestModel
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
