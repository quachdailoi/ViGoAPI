using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class LinkWalletRequest
    {
        public Payments.PaymentMethods PaymentMethod { get; set; }
        public string Applink { get; set; }
    }
}
