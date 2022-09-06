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
        public BookingTypes Type { get; set; }
        public DaySchedule Days { get; set; }
        public bool IsShared { get; set; }
        public Location From { get; set; }
        public Location To { get; set; }
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public StatusTypes.Booking Status { get; set; }

        //promotion view model
    }
    public class BookerBookingViewModel : BookingViewModel
    {
        public List<BookerBookingDetailViewModel> BookingDetails { get; set; }
    }
    public class DriverBookingViewModel : BookingViewModel
    {
        public UserViewModel User { get; set; }
    }
}
