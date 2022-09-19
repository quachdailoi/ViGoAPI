using Domain.Entities.Base;
using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public VehicleTypes VehicleType { get; set; } = VehicleTypes.ViRide;
        public PaymentMethods PaymentMethod { get; set; } = PaymentMethods.COD;
        public Bookings.Options Option { get; set; }
        public Bookings.Types Type { get; set; }
        public DaySchedule Days { get; set; } = new();
        public bool IsShared { get; set; }
        public int StartStationId { get; set; } = new();
        public int EndStationId { get; set; } = new();
        public List<Step> Steps { get; set; } = new();
        public double Duration { get; set; }
        public double Distance { get; set; }

        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public int UserId { get; set; }
        public int? PromotionId { get; set; } = null;
        public StatusTypes.Booking Status { get; set; } = StatusTypes.Booking.Started;

        public User User { get; set; }
        public Station StartStation { get; set; }
        public Station EndStation { get; set; }
        public List<BookingDetail> BookingDetails { get; set; } = new();

        //Promotion
        public Promotion Promotion { get; set; }
    }
}
