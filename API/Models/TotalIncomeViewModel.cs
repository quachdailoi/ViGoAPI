using API.Models.Responses;

namespace API.Models
{
    public class TotalIncomeViewModel
    {
        public DateOnly Date { get; set; }
        public List<IncomeViewModel> Incomes { get; set; } = new();

        public double TotalIncome { get => Incomes.Select(x => x.Amount).Sum(); }
    }
}
