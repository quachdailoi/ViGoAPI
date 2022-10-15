using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AffiliateParty : BaseEntity
    {
        public AffiliateParties.PartyTypes Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public AffiliateParties.Status Status { get; set; } = AffiliateParties.Status.Active;

        public List<AffiliateAccount> AffiliateAccounts = new();
    }
}
