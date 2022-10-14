using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AffiliatePartyType : BaseEntity
    {
        public AffiliatePartyTypes.Types Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public AffiliatePartyTypes.Status Status { get; set; } = AffiliatePartyTypes.Status.Active;

        public List<AffiliateAccount> AffiliateAccounts = new();
    }
}
