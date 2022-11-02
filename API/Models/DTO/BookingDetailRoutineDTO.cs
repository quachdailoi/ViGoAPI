using Domain.Entities;

namespace API.Models.DTO
{
    public class BookingDetailRoutineDTO
    {
        public RouteRoutine Routine { get; set; }
        public IQueryable<BookingDetail> BookingDetails { get; set; }
    }
}
