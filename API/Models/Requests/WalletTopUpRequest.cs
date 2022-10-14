using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class WalletTopUpRequest
    {
        public double Amount { get; set; }
        public AffiliatePartyTypes.Types AffiliatePartyType { get; set; }
    }
}
