using Domain.Entities;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class BookingViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public VehicleTypes VehicleType { get; set; } = VehicleTypes.ViRide;
        public int Option { get; set; }
        public Bookings.Types Type { get; set; }
        public bool IsShared { get; set; }
        public int StartStationId { get; set; } = new();
        public int EndStationId { get; set; } = new();
        public List<Step> Steps { get; set; } = new();
        public double Duration { get; set; }
        public double Distance { get; set; }
        public PaymentMethods PaymentMethod { get; set }

        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public StatusTypes.Booking Status { get; set; } = StatusTypes.Booking.Started;
    }
    public class BookerBookingViewModel : BookingViewModel
    {
        public DaySchedule Days { get; set; } = new();
        public PromotionViewModel? Promotion { get; set; } = null;
        //public List<BookerBookingDetailViewModel> BookingDetails { get; set; }
    }
    public class DriverBookingViewModel : BookingViewModel
    {
        public UserViewModel User { get; set; }
    }
}
