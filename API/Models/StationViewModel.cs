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
        public int Index { get; set; }

        public int CompareTo(StationInRouteViewModel? other)
        {
            return this.Index - other.Index;
        }
    }
}
