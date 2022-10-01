using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class BookingDTO : BaseDTO
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public int VehicleTypeId { get; set; }
        public PaymentMethods PaymentMethod { get; set; } = PaymentMethods.COD;
        public Bookings.Options Option { get; set; } 
        public Bookings.Types Type { get; set; }
        public bool IsShared { get; set; }
        public Guid StartStationCode { get; set; }
        public Guid EndStationCode { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
        public Guid RouteCode { get; set; }
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public Bookings.Status Status { get; set; } = Bookings.Status.Unpaid;
        public int UserId { get; set; }
        public string PromotionCode { get; set; } = string.Empty;
    }
}
