using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WalletTransaction : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public double Amount { get; set; }
        public string TxnId { get; set; } = String.Empty;
        public int? BookingId { get; set; } = null;
        public WalletTransactions.Types Type { get; set; }
        public WalletTransactions.Status Status { get; set; } = WalletTransactions.Status.Pending;
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public Booking? Booking { get; set; } = null;
    }
}
