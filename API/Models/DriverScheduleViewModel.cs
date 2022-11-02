namespace API.Models
{
    public class DriverScheduleViewModel
    {
        public DateOnly Date { get; set; }
        public ICollection<RouteScheduleViewModel> RouteRoutines { get; set; } = new List<RouteScheduleViewModel>();
    }
}
