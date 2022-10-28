using Newtonsoft.Json;

namespace API.Models.Requests
{
    public class ZaloPayPaymentNotificationRequest
    {
        public string data { get; set; }
        public CallBackData parsed_data { get => JsonConvert.DeserializeObject<CallBackData>(data); }
        public string mac { get; set; }
        public string type { get; set; }
    }
    public class CallBackData
    {
        public int app_id { get; set; }
        public string app_trans_id { get; set; }
        public long app_time { get; set; }
        public string app_user { get; set; }
        public long amount { get; set; }
        public string embed_data { get; set; }
        public object parsed_embed_data { get => JsonConvert.DeserializeObject(embed_data); }
        public string item { get; set; }
        public List<object> parsed_item { get => JsonConvert.DeserializeObject<List<object>>(item); }
        public long zp_trans_id { get; set; }
        public long server_time { get; set; }
        public int channel { get; set; }
        public string merchant_user_id { get; set; }
        public long user_fee_amount { get; set; }
        public long discount_amount { get; set; }
    }
}
