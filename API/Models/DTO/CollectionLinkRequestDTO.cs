using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class CollectionLinkRequestDTO
    {

    }
    public class MomoCollectionLinkRequestDTO : CollectionLinkRequestDTO
    {
        private string _redirectUrl = "vigo://12asdxxx";
        public string orderInfo { get; set; } = "Pay with Momo";
        public string? partnerCode { get; set; }
        public string redirectUrl {
            get => _redirectUrl;
            set
            {
                if(!String.IsNullOrEmpty(value)) _redirectUrl = value;
            } 
        }
        public string? ipnUrl { get; set; }
        public long amount { get; set; }
        public string orderId { get; set; } = Guid.NewGuid().ToString();
        public string requestId { get; set; }
        public string extraData { get; set; } = String.Empty;
        public string partnerName { get; set; }
        public string storeId { get; set; }
        public string requestType { get; set; }
        public string orderGroupId { get; set; } = String.Empty;
        public bool autoCapture { get; set; } = true;
        public string lang { get; set; } = "vi";
        public string? signature { get; set; }
        public MomoUserInfoDTO userInfo { get; set; }
        public List<MomoItemRequestDTO> items { get; set; } = new();
    }
    public class MomoLinkingWalletRequestDTO : MomoCollectionLinkRequestDTO
    {
        public string partnerClientId { get; set; }
    }
}
