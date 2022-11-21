using API.Extensions;
using Domain.Entities;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class RouteViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
        public Routes.Status Status { get; set; } = Routes.Status.Active;
        public string StatusName { get => Status.DisplayName(); }
        [JsonIgnore]
        public List<RouteStation> RouteStations { get; set; } = new();
        public List<StationInRouteViewModel> Stations { get; set; } = new();
        public virtual RouteViewModel ProcessStation()
        {
            RouteStations = RouteStations.OrderBy(routeStation => routeStation.DistanceFromFirstStationInRoute).ToList();

            if (RouteStations.Count == 0) return this;
            var stationDic = Stations.DistinctBy(e => e.Id).ToDictionary(e => e.Id);
            List<StationInRouteViewModel> processedStations = new();
            foreach (var routeStation in RouteStations)
            {
                processedStations.Add(stationDic[routeStation.StationId]);
            }
            if(RouteStations.First().Id == RouteStations.Last().NextRouteStationId) processedStations.Add(processedStations.First());

            this.Stations = processedStations;

            return this;
        }
        public ContactUserViewModel? UpdatedByAdmin { get; set; } = null;
    }

    public class BookerRouteViewModel : RouteViewModel
    {
        public FeeViewModel Fee { get; set; }

        public override BookerRouteViewModel ProcessStation() => (BookerRouteViewModel)base.ProcessStation();
    }

    public class StepViewModel
    {
        public double Distance { get; set; }
        public double Duration { get; set; }
        public Location StartPoint { get; set; } = new();
        public Location EndPoint { get; set; } = new();
        public string Maneuver { get; set; } = String.Empty;
        public Bound? Bound { get; set; } = null;
        [JsonIgnore]
        public int? StationId = null;
        public StationViewModel? Station { get; set; } = null;
    }

    public class RouteScheduleViewModel
    {
        public string RouteCode { get; set; }
        public TimeOnly StartTime { get; set; }
        public List<ScheduleBookingDetailViewModel> Schedules { get; set; } = new();
        public List<StepScheduleViewModel> Steps { get; set; } = new();
    }
}
