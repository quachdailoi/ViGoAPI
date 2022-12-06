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
        [JsonIgnore]
        public BookingDetailDrivers.TripStatus? DriverStatus
        {
            get => Driver?.TripStatus;
            set
            {
                if (Driver != null && value.HasValue)
                {
                    Driver.TripStatus = value.Value;
                }
            }
        }
        [JsonIgnore]
        public Guid? BookingDetailDriverCode
        {
            get => Driver?.BookingDetailDriverCode;
            set
            {
                if(Driver != null && value.HasValue)
                {
                    Driver.BookingDetailDriverCode = value.Value;
                }
            }
        }
    }

    public class BookerBookingDetailWithStationsViewModel : BookerBookingDetailViewModel
    {
        //[JsonIgnore]
        //public new StationInRouteViewModel StartStation { get; set; }
        //[JsonIgnore]
        //public new StationInRouteViewModel EndStation { get; set; }
        [JsonIgnore]
        public RouteStation StartRouteStation { get; set; }
        [JsonIgnore]
        public RouteStation EndRouteStation { get; set; }
        [JsonIgnore]
        public List<RouteStation> RouteStations { get; set; }
        private List<StationInRouteViewModel> _Stations = new();
        public List<StationInRouteViewModel> Stations
        {
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

                //var startStation = value.Where(station => station.Id == this.StartStation.Id).First();
                //var endStation = value.Where(station => station.Id == this.EndStation.Id).First();

                //value = value.OrderBy(station => station.DistanceFromFirstStationInRoute).ToList();

                //var stationAfterStart = value.Where(station => station.DistanceFromFirstStationInRoute >= startStation.DistanceFromFirstStationInRoute).ToList();
                //var stationBeforeEnd = value.Where(station => station.DistanceFromFirstStationInRoute <= endStation.DistanceFromFirstStationInRoute).ToList();

                //value = startStation.DistanceFromFirstStationInRoute <= endStation.DistanceFromFirstStationInRoute ?
                //    stationAfterStart.Intersect(stationBeforeEnd).ToList() : stationAfterStart.Concat(stationBeforeEnd).ToList();


                _Stations = stations;
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
