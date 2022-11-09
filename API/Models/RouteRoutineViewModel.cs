using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Models
{
    public class RouteRoutineViewModel
    {
        public string RouteCode { get; set; }
        public double Distance { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<StationViewModel> Stations { get; set; }
        public RouteRoutines.Status Status { get; set; }
    }
}
