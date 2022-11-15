namespace API.Models
{
    public class IncomeViewModel
    {
        public Guid TransactionCode { get; set; }
        public double Amount { get; set; }
        public int BookingId { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
