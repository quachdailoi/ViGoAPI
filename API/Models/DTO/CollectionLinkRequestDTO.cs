namespace API.Models.DTO
{
    public class CollectionLinkRequestDTO
    {

    }
    public class MomoCollectionLinkRequestDTO : CollectionLinkRequestDTO
    {
        public string OrderInfo { get; set; } = "Pay with Momo";
        public string PartnerCode { get; set; }
        public string RedirectUrl { get; set; } = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b";
        public string IpnUrl { get; set; } = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b";
        public long Amount { get; set; }
        public string OrderId { get; set; }
        public string RequestId { get; set; }
        public string ExtraData { get; set; } = String.Empty;
        public string PartnerName { get; set; }
        public string StoreId { get; set; }
        public string RequestType { get; set; } = "payWithMethod";
        public string OrderGroupId { get; set; } = String.Empty;
        public bool AutoCapture { get; set; } = true;
        public string Lang { get; set; } = "vi";
        public string Signature { get; set; }
        public MomoUserInfoDTO UserInfo { get; set; }
        public List<MomoItemRequestDTO> Items { get; set; } = new();
    }
}
