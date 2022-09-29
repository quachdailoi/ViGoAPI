using API.Extensions;
using API.Models.DTO;
using API.Models.Settings;
using API.Services.Constract;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using Newtonsoft.Json;

namespace API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        public PaymentService(IConfiguration config)
        {
            _client = new HttpClient();
            _config = config;
        }
        public async Task<string> GenerateMomoPaymentUrl(int orderId, long amount, List<MomoItemRequestDTO> items, MomoUserInfoDTO userInfo)
        {
            var dto = new MomoCollectionLinkRequestDTO
            {
                partnerCode = _config.Get(MomoSettings.PartnerCode),
                partnerName = _config.Get(MomoSettings.PartnerName),
                storeId = _config.Get(MomoSettings.StoreId),
                requestId = Guid.NewGuid().ToString(),
                amount = amount,
                orderId = Guid.NewGuid().ToString(),
                //items = items,
                //userInfo = userInfo
            };

            var rawSignature = $"amount={dto.amount}&extraData={dto.extraData}&ipnUrl={dto.ipnUrl}" +
                $"&orderId={dto.orderId}&orderInfo={dto.orderInfo}&partnerCode={dto.partnerCode}&redirectUrl={dto.redirectUrl}" +
                $"&requestId={dto.requestId}&requestType={dto.requestType}";

            dto.signature = GetMomoSignature(rawSignature);

            StringContent httpContent = new(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://test-payment.momo.vn/v2/gateway/api/create", httpContent);
            
            var body = await response.Content.ReadAsStringAsync();

            var bodyJson = JToken.Parse(body);

            //return new Dictionary<string, string>
            //{
            //    { "WebLink", bodyJson.Value<string>("payUrl") ?? String.Empty},
            //    { "DeepLink", bodyJson.Value<string>("deepLink") ?? String.Empty }
            //};
            return bodyJson.Value<string>("payUrl") ?? String.Empty;
        }

        public async Task<string> GenerateMomoPaymentUrl(MomoCollectionLinkRequestDTO dto)
        {
            dto.partnerCode = _config.Get(MomoSettings.PartnerCode);
            dto.partnerName = _config.Get(MomoSettings.PartnerName);
            dto.storeId = _config.Get(MomoSettings.StoreId);
            dto.requestId = Guid.NewGuid().ToString();

            var rawSignature = $"amount={dto.amount}&extraData={dto.extraData}&ipnUrl={dto.ipnUrl}" +
                $"&orderId={dto.orderId}&orderInfo={dto.orderInfo}&partnerCode={dto.partnerCode}&redirectUrl={dto.redirectUrl}" +
                $"&requestId={dto.requestId}&requestType={dto.requestType}";

            dto.signature = GetMomoSignature(rawSignature);

            StringContent httpContent = new(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://test-payment.momo.vn/v2/gateway/api/create", httpContent);

            var body = await response.Content.ReadAsStringAsync();

            var bodyJson = JToken.Parse(body);

            //return new Dictionary<string, string>
            //{
            //    { "WebLink", bodyJson.Value<string>("payUrl") ?? String.Empty},
            //    { "DeepLink", bodyJson.Value<string>("deepLink") ?? String.Empty }
            //};
            return bodyJson.Value<string>("payUrl") ?? String.Empty;
        }
        public string GetMomoSignature(string text)
        {
            var accessKey = _config.Get(MomoSettings.AccessKey);
            var secretKey = _config.Get(MomoSettings.SecretKey);

            var rawSignature = $"accessKey={accessKey}&{text}";

            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(rawSignature);
            Byte[] keyBytes = encoding.GetBytes(secretKey);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
