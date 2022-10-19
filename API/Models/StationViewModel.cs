using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class StationViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class StationInRouteViewModel : StationViewModel , IComparable<StationInRouteViewModel>
    {
        //public double DistanceFromFirstStationInRoute { get; set; }
        [JsonIgnore]
        public double DistanceFromFirstStationInRoute { get; set; }
        [JsonIgnore]
        public double DurationFromFirstStationInRoute { get; set; }

        public int CompareTo(StationInRouteViewModel? other)
        {
            var distance = this.DistanceFromFirstStationInRoute - other.DistanceFromFirstStationInRoute;
            if (distance < 0) return -1;
            else if(distance > 0) return 1;
            return 0;
        }
    }

    public class ScheduleStationViewModel
    {
        public string? Name { get; set; }
        public Guid Code { get; set; }
        public string? Address { get; set; }

        [JsonIgnore]
        public int Index { get; set; }
    }
}
