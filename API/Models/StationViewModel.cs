using Domain.Shares.Enums;

namespace API.Models
{
    public class StationViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int UpdatedBy { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = String.Empty;
        public StatusTypes.Station Status { get; set; } = StatusTypes.Station.Active;
    }
}
