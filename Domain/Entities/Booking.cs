using Domain.Entities.Base;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public PaymentMethods PaymentMethod { get; set; } = PaymentMethods.COD;
        public Bookings.Options Option { get; set; }
        public Bookings.Types Type { get; set; }
        public bool IsShared { get; set; }
        public Guid StartStationCode { get; set; }
        public Guid EndStationCode { get; set; }
        public double Duration { get; set; }
        public double Distance { get; set; }

        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public int UserId { get; set; }
        public int? PromotionId { get; set; } = null;
        public int RouteId { get; set; }
        public int VehicleTypeId { get; set; }
        public Bookings.Status Status { get; set; } = Bookings.Status.Unpaid;

        public User User { get; set; }
        public Route Route { get; set; }
        public VehicleType VehicleType { get; set; }
        public List<BookingDetail> BookingDetails { get; set; } = new();

        //Promotion
        public Promotion? Promotion { get; set; } = null;

        // Virtual Relationship
        public Station StartStation { get; set; }
        public Station EndStation { get; set; }
    }
}
