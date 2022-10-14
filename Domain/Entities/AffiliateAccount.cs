using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AffiliateAccount : BaseEntity
    {
        public string Token { get; set; }
        public Object ExtraData { get; set; } = new();
        public AffiliateAccounts.Status Status { get; set; } = AffiliateAccounts.Status.Active;
        public int WalletId { get; set; }
        public AffiliatePartyTypes.Types AffiliatePartyTypeId { get; set; }

        public Wallet Wallet { get; set; }
        public AffiliatePartyType AffiliatePartyType { get; set; }
    }
}
