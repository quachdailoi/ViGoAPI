namespace API.Models
{
    public class IncomeViewModel
    {
        public Guid BookingDetailCode { get; set; }
        public double? Rating { get; set; } = null!;
        public string? FeedBack { get; set; } = null!;
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
    }
}
