namespace API.Models.DTO
{
    public class BookingRoutineDTO
    {
        public Domain.Entities.Route Route { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
