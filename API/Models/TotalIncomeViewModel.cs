using API.Models.Responses;

namespace API.Models
{
    public class TotalIncomeViewModel
    {
        public IQueryable<IncomeViewModel> Incomes { get; set; }

        public double Total { get => Incomes.Select(x => x.Price).Sum(); }

        public double Discount { get => Incomes.Select(x => x.DiscountPrice).Sum(); }

        public double TotalIncome { get => Total - Discount; }
    }
}
