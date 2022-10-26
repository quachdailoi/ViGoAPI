using API.Extensions;
using Domain.Entities;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class BookingDetailViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; }
        public double Rating { get; set; }
        public string FeedBack { get; set; } = String.Empty;
        public DateOnly Date { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public BookingDetails.Status Status { get; set; }
        public string StatusName { get => Status.DisplayName(); }
        public Guid? ChattingRoomCode { get; set; }
        public TimeOnly Time { get; set; }
        public StationInRouteViewModel StartStation { get; set; }
        public StationInRouteViewModel EndStation { get; set; }
        [JsonIgnore]
        public BookingDetailDriver? BookingDetailDriver { get; set; } = null;
    }
    public class BookerBookingDetailViewModel : BookingDetailViewModel
    {
        public Guid BookingCode { get; set; }
        public string BookingType { get; set; }
        public DriverInBookingDetailViewModel? Driver { get; set; } = null;
        public BookingDetailDrivers.Status? DriverStatus
        {
            get => Driver?.Status;
            set
            {
                if (Driver != null && value.HasValue)
                {
                    Driver.Status = value.Value;
                }
            }
        }
    }
    public class DriverBookingDetailViewModel : BookingDetailViewModel
    {
        public ContactUserViewModel User { get; set; }
    }

    public class ScheduleBookingDetailViewModel
    {
        public Guid BookingDetailDriverCode { get; set; }
        public TimeOnly Time { get; set; }
        public ScheduleStationViewModel StartStation { get; set; }
        public ScheduleStationViewModel EndStation { get; set; }
        public double Distance { get; set; }
        public BookingDetailDrivers.TripStatus TripStatus { get; set; }

        public ScheduleUserViewModel User { get; set; } = new();
    }
}
