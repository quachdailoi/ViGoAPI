using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class UpdateStationRequest
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public int StationStatus { get; set; } = (int)Stations.Status.Active;
    }
}
