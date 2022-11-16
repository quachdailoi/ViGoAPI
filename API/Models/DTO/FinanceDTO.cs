namespace API.Models.DTO
{
    public class FinanceDTO
    {
        public double TotalRevenue { get; set; }
        public double Profit { get => TotalRevenue - (TotalRefund + TotalPayForDriver); }
        public double TotalRefund { get; set; }
        public double TotalPayForDriver { get; set; }
    }
}
