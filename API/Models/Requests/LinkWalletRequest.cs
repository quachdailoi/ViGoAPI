using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class LinkWalletRequest
    {
        public AffiliateParties.PartyTypes Type { get; set; }
    }
}
