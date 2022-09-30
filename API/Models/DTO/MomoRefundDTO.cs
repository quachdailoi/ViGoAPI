namespace API.Models.DTO
{
    public class MomoRefundDTO
    {
        public string partnerCode { get; set; }
        public string? subPartnerCode { get; set; } = null;
        public string orderId { get; set; } // id for refund transaction, not booking id
        public string requestId { get; set; }   
        public long amount { get; set; }
        public long transId { get; set; }
        public string lang { get; set; } = "vi";
        public string description { get; set; } = String.Empty;
        public string signature { get; set; } = String.Empty;
    }
}
