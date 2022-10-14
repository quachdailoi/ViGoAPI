using Domain.Shares.Enums;

namespace API.Models
{
    public class AffiliateAccountViewModel
    {
        public AffiliatePartyTypes.Types Type { get; set; }
        public string Name { get; set; }
        public object ExtraData { get; set; }
    }
}
