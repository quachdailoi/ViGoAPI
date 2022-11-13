using Domain.Entities;

namespace API.Models.DTO
{
    public class TimelineDTO
    {
        public TimeOnly Time { get; set; }
        public Station Station { get; set; }
        public RouteRoutine Routine { get; set; }
    }
}
