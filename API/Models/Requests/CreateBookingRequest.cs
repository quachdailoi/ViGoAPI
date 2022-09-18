using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class CreateBookingRequest
    {
        public double TotalPrice { get; set; }
        //public double DiscountPrice { get; set; }
        public VehicleTypes VehicleType { get; set; } = VehicleTypes._4_SEAT_CAR;
        public string Time { get; set; }
        //public TimeOnly Time { get; set; }
        public Bookings.Options Option { get; set; } = Bookings.Options.None;
        public Bookings.Types Type { get; set; }
        public DaySchedule Days { get; set; } = new();
        public bool IsShared { get; set; }
        public Guid StartStationCode { get; set; } = new();
        public Guid EndStationCode { get; set; } = new();
        public double Duration { get; set; }
        public double Distance { get; set; }
        public List<Step> Steps { get; set; } = new();

        public string StartAt { get; set; }
        public string EndAt { get; set; }

        public string PromotionCode { get; set; } = string.Empty;
    }
}
