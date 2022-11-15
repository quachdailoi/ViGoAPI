using API.Models.Responses;

namespace API.Models
{
    public class TotalIncomeViewModel
    {
        public DateOnly Date { get => DateOnly.FromDateTime(Incomes.FirstOrDefault().DateTime.DateTime); }
        public List<IncomeViewModel> Incomes { get; set; }

        public double TotalIncome { get => Incomes.Select(x => x.Amount).Sum(); }
    }
}
