using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class BookingDTO : BaseDTO
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly Time { get; set; }
        public TimeOnly EndTime { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; } = 0;
        public int Option { get; set; }
        public BookingTypes Type { get; set; }
        public DaySchedule Days { get; set; }
        public bool IsShared { get; set; } = false;
        public Location StartPoint { get; set; }
        public Location EndPoint { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
        public Bound Bound { get; set; } = new();
        public List<Step> Steps { get; set; }
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public StatusTypes.Booking Status { get; set; } = StatusTypes.Booking.Started;
        public int UserId { get; set; }
    }
}
