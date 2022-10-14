using Domain.Shares.Enums;

namespace API.Models
{
    public class WalletTransactionViewModel
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public double Amount { get; set; }
        public WalletTransactions.Types Type { get; set; }
        public string TypeName { get; set; }
        public WalletTransactions.Status Status { get; set; }
        public string StatusName { get; set; }
    }
}
