
using Domain.Entities;

namespace API.Models.DTO
{
    public class DistanceStationDTO : IComparable<DistanceStationDTO>
    {
        public StationViewModel Station { get; set; }
        public double Distance { get; set; } // meters
        public double Time { get; set; } // seconds

        public int CompareTo(DistanceStationDTO? other)
        {
            var distanceCompare = Distance.CompareTo(other.Distance);

            if (distanceCompare != 0) return distanceCompare;

            return Time.CompareTo(other.Time);
        }
    }
}
