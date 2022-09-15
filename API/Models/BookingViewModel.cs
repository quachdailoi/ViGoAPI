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
        public Guid Code { get; set; }
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public int Option { get; set; }
        public Bookings.Type Type { get; set; }       
        public bool IsShared { get; set; }
        public Location StartPoint { get; set; } = new();
        public Location EndPoint { get; set; } = new();
        public List<Step> Steps { get; set; } = new();
        public double Duration { get; set; }
        public double Distance { get; set; }

        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
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
