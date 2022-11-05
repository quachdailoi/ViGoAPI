using API.Extensions;
using API.Models.DTO;
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
        public Payments.PaymentMethods PaymentMethod { get; set; }
        [JsonIgnore]
        public RouteStation StartRouteStation { get; set; }
        [JsonIgnore]
        public RouteStation EndRouteStation { get; set; }
        public Bookings.Status Status { get; set; } = Bookings.Status.Unpaid;
        public string StatusName { get => Status.DisplayName(); }
        [JsonIgnore]
        private List<StationInRouteViewModel> _Stations = new();
        public List<StationInRouteViewModel> Stations { 
            get => _Stations;
            set 
            {
                var startStation = value.Where(station => station.Id == this.StartRouteStation.StationId).First();
                var endStation = value.Where(station => station.Id == this.EndRouteStation.StationId).First();

                value = value.OrderBy(station => station.DistanceFromFirstStationInRoute).ToList();

                var stationAfterStart = value.Where(station => station.DistanceFromFirstStationInRoute >= startStation.DistanceFromFirstStationInRoute).ToList();
                var stationBeforeEnd = value.Where(station => station.DistanceFromFirstStationInRoute <= endStation.DistanceFromFirstStationInRoute).ToList();

                value = startStation.DistanceFromFirstStationInRoute <= endStation.DistanceFromFirstStationInRoute ?
                    stationAfterStart.Intersect(stationBeforeEnd).ToList() : stationAfterStart.Concat(stationBeforeEnd).ToList();

                _Stations = value;
            } 
        }

    }
    public class BookerBookingViewModel : BookingViewModel
    {
        public PromotionViewModel? Promotion { get; set; } = null;
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public int Option { get; set; }
        //public Bookings.Types Type { get; set; }
        //public string TypeName { get => Type.DisplayName(); }
        public List<DayOfWeek> DayOfWeeks { get; set; } = new();
        public string CreatedAt { get; set; }
    }
    public class DriverBookingViewModel : BookingViewModel
    {
        public UserViewModel User { get; set; }
    }

    public class PaymentBookingViewModel
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public WalletTransactionDTO WalletTransaction { get; set; }
    }
}
