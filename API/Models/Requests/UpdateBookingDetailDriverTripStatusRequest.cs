using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class UpdateBookingDetailDriverTripStatusRequest
    {
        public string BookingDetailDriverCode { get; set; }
        public BookingDetailDrivers.TripStatus TripStatus { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class StartBookingDetailDriversRequest
    {
        public string[] BookingDetailDriverCodes { get; set; }
    }

    public class CancelBookingDetailDriversRequest
    {
        public string[] BookingDetailDriverCodes { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
