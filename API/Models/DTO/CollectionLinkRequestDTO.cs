namespace API.Models.DTO
{
    public class CollectionLinkRequestDTO
    {

    }
    public class MomoCollectionLinkRequestDTO : CollectionLinkRequestDTO
    {
        private string _redirectUrl;
        public string orderInfo { get; set; } = "Pay with Momo";
        public string partnerCode { get; set; }
        public string redirectUrl {
            get => _redirectUrl;
            set => _redirectUrl = String.IsNullOrEmpty(value) ? "vigo://12asdxxx" : value;
        }
        public string ipnUrl { get; set; }
        public long amount { get; set; }
        public string orderId { get; set; }
        public string requestId { get; set; }
        public string extraData { get; set; } = String.Empty;
        public string partnerName { get; set; }
        public string storeId { get; set; }
        public string requestType { get; set; } = "captureWallet";
        public string orderGroupId { get; set; } = String.Empty;
        public bool autoCapture { get; set; } = true;
        public string lang { get; set; } = "vi";
        public string signature { get; set; }
        public MomoUserInfoDTO userInfo { get; set; }
        public List<MomoItemRequestDTO> items { get; set; } = new();
    }
}
