using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class WalletTopUpRequest
    {
        public double Amount { get; set; }
        public AffiliateParties.PartyTypes Type { get; set; } = AffiliateParties.PartyTypes.Momo;
    }
}