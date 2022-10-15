using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public double Balance { get; set; }
        public Wallets.Status Status { get; set; } = Wallets.Status.Active;
        public int UserId { get; set; }

        public User User { get; set; }
        public List<AffiliateAccount> AffiliateAccounts = new();
        public List<WalletTransaction> WalletTransactions = new();
    }
}
