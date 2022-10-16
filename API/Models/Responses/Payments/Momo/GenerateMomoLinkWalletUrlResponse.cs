namespace API.Models.Responses.Payments.Momo
{
    public class GenerateMomoLinkWalletUrlResponse : GenerateMomoPaymentUrlResponse
    {
        public string partnerClientId { get; set; }
    }
}
