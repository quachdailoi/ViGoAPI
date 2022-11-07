using API.Models.Responses;

namespace API.Models
{
    public class TotalIncomeViewModel
    {
        public PagingViewModel<IQueryable<IncomeViewModel>> Incomes { get; set; }

        public double Total { get => Incomes.Items.Select(x => x.Price).Sum(); }

        public double Discount { get => Incomes.Items.Select(x => x.DiscountPrice).Sum(); }

        public double TotalIncome { get => Total - Discount; }
    }
}
