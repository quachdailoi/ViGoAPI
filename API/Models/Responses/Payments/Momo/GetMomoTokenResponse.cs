namespace API.Models.Responses.Payments.Momo
{
    public class GetMomoTokenResponse
    {
        public string partnerCode { get; set; }
        public string requestId { get; set; }
        public string orderId { get; set; }
        public string aesToken { get; set; }
        public string partnerClientId { get; set; }
        public long responseTime { get; set; }
        public string message { get; set; }
        public int resultCode { get; set; }
    }
}
