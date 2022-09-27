namespace API.Models.DTO
{
    public class CollectionLinkRequestDTO
    {

    }
    public class MomoCollectionLinkRequestDTO : CollectionLinkRequestDTO
    {
        public string OrderInfo { get; set; }
        public string PartnerCode { get; set; }
        public string RedirectUrl { get; set; }
        public string IpnUrl { get; set; }
        public long Amount { get; set; }
        public string OrderId { get; set; }
        public string RequestId { get; set; }
        public string ExtraData { get; set; }
        public string PartnerName { get; set; }
        public string StoreId { get; set; }
        public string RequestType { get; set; }
        public string OrderGroupId { get; set; }
        public bool AutoCapture { get; set; }
        public string Lang { get; set; }
        public string Signature { get; set; }
        public MomoUserInfoDTO UserInfo { get; set; }
        public List<MomoItemRequestDTO> Items { get; set; } = new();
    }
}
