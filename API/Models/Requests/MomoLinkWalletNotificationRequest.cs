﻿namespace API.Models.Requests
{
    public class MomoLinkWalletNotificationRequest
    {
        public string partnerCode { get; set; }
        public string orderId { get; set; }
        public string requestId { get; set; }
        public long amount { get; set; }
        public string orderInfo { get; set; }
        public string partnerUserId { get; set; }
        public string orderType { get; set; }
        public string partnerClientId { get; set; }
        public string callbackToken { get; set; }
        public long transId { get; set; }
        public int resultCode { get; set; }
        public string message { get; set; }
        public string payType { get; set; }
        public long responseTime { get; set; }
        public string extraData { get; set; }
        public string signature { get; set; }
    }
}
