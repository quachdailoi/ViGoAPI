namespace API.Models.Requests
{
    public class GetMomoTokenRequest
    {
        public string partnerCode { get; set; }
        public string callbackToken { get; set; }
        public string requestId { get; set; }
        public string orderId { get; set; }
        public string partnerClientId { get; set; }
        public string lang { get; set; } = "vi";
        public string signature { get; set; }
    }
}
