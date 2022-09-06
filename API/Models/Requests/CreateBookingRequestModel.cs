using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class CreateBookingRequestModel
    {
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; } = 0;
        public int Option { get; set; }
        public BookingTypes Type { get; set; }
        public DaySchedule Days { get; set; }
        public bool IsShared { get; set; } = false;
        public Location From { get; set; }
        public Location To { get; set; }
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
    }
}
