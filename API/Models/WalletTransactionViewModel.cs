using API.Extensions;
using Domain.Shares.Enums;

namespace API.Models
{
    public class WalletTransactionViewModel
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public double Amount { get; set; }
        public WalletTransactions.Types Type { get; set; }
        public string TypeName { get => Type.DisplayName(); }
        public WalletTransactions.Status Status { get; set; }
        public string StatusName { get => Status.DisplayName(); }
        public string Time { get; set; }
        public Guid? BookingCode { get; set; } = null;
    }
}
