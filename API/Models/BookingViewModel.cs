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
        [JsonIgnore]
        public List<RouteStation> RouteStations { get; set; }
        public Bookings.Status Status { get; set; } = Bookings.Status.Unpaid;
        public string StatusName { get => Status.DisplayName(); }
        [JsonIgnore]
        private List<StationInRouteViewModel> _Stations = new();
        public List<StationInRouteViewModel> Stations { 
            get => _Stations;
            set 
            {
                var routeStationDic = RouteStations.ToDictionary(x => x.Id);

                var stationDic = value.DistinctBy(x => x.Id).ToDictionary(x => x.Id);

                var currentRouteStation = StartRouteStation;

                var stations = new List<StationInRouteViewModel>();

                while (true)
                {
                    stations.Add(stationDic[currentRouteStation.StationId]);

                    if (currentRouteStation.StationId == EndRouteStation.StationId ||
                        !currentRouteStation.NextRouteStationId.HasValue) break;

                    currentRouteStation = routeStationDic[currentRouteStation.NextRouteStationId.Value];
                }

                _Stations = stations;
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
