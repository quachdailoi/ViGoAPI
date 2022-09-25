using Domain.Entities;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class RouteViewModel
    { 
        //public Location StartPoint { get; set; } = new();
        //public Location EndPoint { get; set; } = new();
        public int Id { get; set; }
        //public List<Step> Steps { get; set; } = new();
        public double Distance { get; set; }
        public double Duration { get; set; }
        //public Bound Bound { get; set; } = new();
        public StatusTypes.Route Status { get; set; } = StatusTypes.Route.Active;
        [JsonIgnore]
        public List<RouteStation> RouteStations { get; set; } = new();
        public List<StationInRouteViewModel> Stations { get; set; } = new();
    }

    public class BookerRouteViewModel : RouteViewModel
    {
        public double Fee { get; set; }
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
}
