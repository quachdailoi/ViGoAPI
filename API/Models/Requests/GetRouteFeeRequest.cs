using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class GetRouteFeeRequest
    {
        public Guid StartStationCode { get; set; }
        public Guid EndStationCode { get; set; }
        //public Bookings.Types BookingType { get; set; } = Bookings.Types.MonthTicket;
        public List<DayOfWeek> DayOfWeeks { get; set; } = new();
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public string Time { get; set; }
        public Guid VehicleTypeCode { get; set; }
    }
}
