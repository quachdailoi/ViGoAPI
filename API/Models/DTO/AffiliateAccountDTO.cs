using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class AffiliateAccountDTO : BaseDTO
    {
        public string Token { get; set; }
        public Object ExtraData { get; set; } = new();
        public AffiliateAccounts.Status Status { get; set; } = AffiliateAccounts.Status.Active;
        public int UserId { get; set; }
        public Payments.PaymentMethods Type { get; set; }
    }
}
