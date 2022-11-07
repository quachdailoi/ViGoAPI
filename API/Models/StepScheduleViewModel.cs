using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class StepScheduleViewModel
    {
        public Guid BookingDetailDriverCode { get; set; }
        public BookingDetailDrivers.TripStatus TripStatus { get; set; }
        public Guid StationCode { get; set; }
        public string StationName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string UserName { get; set; }
        public BookingDetailDrivers.StepScheduleType Type { get; set; }

        [JsonIgnore]
        public int Index { get; set; }

        [JsonIgnore]
        public TimeOnly Time { get; set; }
    }
}
