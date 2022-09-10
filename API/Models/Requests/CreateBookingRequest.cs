using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class CreateBookingRequest
    {
        //public double TotalPrice { get; set; }
        //public double DiscountPrice { get; set; }
        public string Time { get; set; }
        //public TimeOnly Time { get; set; }
        public int Option { get; set; }
        public BookingTypes Type { get; set; }
        public DaySchedule Days { get; set; } = new();
        public bool IsShared { get; set; }
        public Location StartPoint { get; set; } = new();
        public Location EndPoint { get; set; } = new();
        //public double Duration { get; set; }
        //public double Distance { get; set; }
        //public List<Step> Steps { get; set; } = new();

        public string StartAt { get; set; }
        public string EndAt { get; set; }
        //public DateOnly StartAt { get; set; }
        //public DateOnly EndAt { get; set; }
    }
}
