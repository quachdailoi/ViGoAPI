namespace API.Models
{
    public class IncomeViewModel
    {
        public Guid TransactionCode { get; set; }
        public double Amount { get; set; }
        public int BookingId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public StationViewModel StartStation { get; set; }
        public StationViewModel EndStation { get; set; }
    }
}
