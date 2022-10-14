using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class WalletTransactionDTO : BaseDTO
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public double Amount { get; set; }
        public string TxnId { get; set; }
        public WalletTransactions.Types Type { get; set; }
        public WalletTransactions.Status Status { get; set; } = WalletTransactions.Status.Pending;
        public int WalletId { get; set; }
        //public Wallet Wallet { get; set; }
    }
}
