namespace API.Models
{
    public class DriverScheduleViewModel
    {
        public DateOnly Date { get; set; }
        public List<RouteScheduleViewModel> Routes { get; set; } = new();
    }
}
