using Domain.Entities;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class BookingViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public VehicleTypeViewModel VehicleType { get; set; }
        public bool IsShared { get; set; }
        public double Duration { get; set; }
        public double Distance { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        [JsonIgnore]
        public Guid StartStationCode { get; set; }
        [JsonIgnore]
        public Guid EndStationCode { get; set; }
        public StatusTypes.Booking Status { get; set; } = StatusTypes.Booking.Started;
        public List<StationInRouteViewModel> Stations { get; set; } = new();

        public virtual BookingViewModel ProcessStationOrder()
        {
            var startIndex = this.Stations.Where(station => station.Code == this.StartStationCode).First().Index;
            var endIndex = this.Stations.Where(station => station.Code == this.EndStationCode).First().Index;

            this.Stations = this.Stations.OrderBy(station => station.Index).ToList();

            var stationAfterStart = this.Stations.Where(station => station.Index >= startIndex).ToList();
            var stationBeforeEnd = this.Stations.Where(station => station.Index <= endIndex).ToList();

            this.Stations = startIndex <= endIndex ?
                stationAfterStart.Intersect(stationBeforeEnd).ToList() : stationAfterStart.Concat(stationBeforeEnd).ToList();
            return this;
        }
    }
    public class BookerBookingViewModel : BookingViewModel
    {
        public PromotionViewModel? Promotion { get; set; } = null;
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public int Option { get; set; }
        public Bookings.Types Type { get; set; }

        public override BookerBookingViewModel ProcessStationOrder()
        {
            return (BookerBookingViewModel)base.ProcessStationOrder();
        }
        //public List<BookerBookingDetailViewModel> BookingDetails { get; set; }
    }
    public class DriverBookingViewModel : BookingViewModel
    {
        public UserViewModel User { get; set; }
    }
}
