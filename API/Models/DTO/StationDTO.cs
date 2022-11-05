using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class StationDTO : BaseDTO
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Stations.Status Status { get; set; } = Stations.Status.Active;
    }
    public class StationWithScheduleDTO
    {
        public Guid StartStationCode { get; set; }
        public int StartStationId { get; set; }
        public Guid EndStationCode { get; set; }
        public int EndStationId { get; set; }
        //public Bookings.Types BookingType { get; set; } = Bookings.Types.MonthTicket;
        public List<DayOfWeek> DayOfWeeks { get; set; } = new();
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public Guid VehicleTypeCode { get; set; }
        public int VehicleTypeId { get; set; }
        public TimeOnly Time { get; set; }
    }
}
