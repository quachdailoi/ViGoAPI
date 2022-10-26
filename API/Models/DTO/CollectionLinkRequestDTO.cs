using API.Extensions;
using Domain.Shares.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class CollectionLinkRequestDTO
    {

    }
    public class MomoCollectionLinkRequestDTO : CollectionLinkRequestDTO
    {
        private string _redirectUrl = "vigo://";
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
    public class ZaloCollectionLinkRequestDTO : CollectionLinkRequestDTO
    {
        public int app_id { get; set; }
        
        [MaxLength(50)]
        public string app_user { get; set; } = "Vigo";

        [MaxLength(40)]
        public string app_trans_id { get => $"{DateTimeExtensions.NowDateOnly.ToFormatString("yyMMdd")}_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}{(new Random()).Next()%10}"; }
        //[JsonIgnore]
        //public int? order_id
        //{
        //    get {
        //        var items = app_trans_id.Split("_");
        //        if (items.Any() && items.Count() == 2)
        //        {
        //            return int.Parse(items[1]);
        //        }
        //        return null;
        //    }
        //    set => app_trans_id = $"{DateTimeExtensions.NowDateOnly.ToFormatString("yyMMdd")}_{value}";
        //}

        public long app_time { get; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        
        public long amount { get; set; }

        [MaxLength(2048)]
        public string item { get; private set; } = "[]";
        [JsonIgnore]
        public List<object> raw_item
        {
            get => JsonConvert.DeserializeObject<List<object>>(item) ?? new();
            set => item = JsonConvert.SerializeObject(value);
        }

        [MaxLength(256)]
        public string description { get => $"Vigo - Pay Booking # {app_trans_id}"; }

        [MaxLength(1024)]
        public string embed_data { get; private set; } = "{}";
        [JsonIgnore]
        public ZaloCollectionLinkRequestEmbedData? raw_embed_data
        {
            get => JsonConvert.DeserializeObject<ZaloCollectionLinkRequestEmbedData>(embed_data) ?? null;
            set => JsonConvert.SerializeObject(value);
        }

        public string bank_code { get; set; } = "";

        public string mac { get; set; }

        public string callback_url { get; set; }

        [MaxLength(256)]
        public string device_info { get; set; }

        [MaxLength(50)]
        public string sub_app_id { get; set; }

        [MaxLength(256)]
        public string title { get; set; }

        public string currency { get; } = "VND";

        [MaxLength(50)]
        public string phone { get; set; }

        [MaxLength(100)]
        public string email { get; set; }

        [MaxLength]
        public string address { get; set; }
        
        [JsonIgnore]
        public string mac_data
        {
            get => app_id + "|" + app_trans_id + "|" + app_user + "|" + amount + "|" + app_time + "|" + embed_data + "|" + item;
        }
    }

    public class ZaloCollectionLinkRequestEmbedData
    {
        public string redirecturl { get; set; } = "vigo://";
        public string columninfo { get; set; } = string.Empty;
        public string promotioninfo { get; private set; } = string.Empty;
        [JsonIgnore]
        public object? rawpromotioninfo
        {
            get => JsonConvert.DeserializeObject(promotioninfo);
            set => promotioninfo = JsonConvert.SerializeObject(value);
        }
        public string zlppaymentid { get; set; } = string.Empty;
    }
}
