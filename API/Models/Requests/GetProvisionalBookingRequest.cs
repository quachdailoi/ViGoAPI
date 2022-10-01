using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class GetProvisionalBookingRequest
    {
        public Guid VehicleTypeCode { get; set; }
        public string Time { get; set; }
        public Bookings.Types Type { get; set; } = Bookings.Types.MonthTicket;
        //public PaymentMethods PaymentMethod { get; set; } = PaymentMethods.COD;
        //public bool IsShared { get; set; }
        public Guid StartStationCode { get; set; } = new();
        public Guid EndStationCode { get; set; } = new();
        public Guid RouteCode { get; set; }

        public string StartAt { get; set; }
        public string EndAt { get; set; }

        public string PromotionCode { get; set; } = string.Empty;
    }
}
