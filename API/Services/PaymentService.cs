using API.Extensions;
using API.Models.DTO;
using API.Models.Settings;
using API.Services.Constract;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

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
        public async Task<Dictionary<string,string>> GenerateMomoPaymentUrl(int orderId, long amount, List<MomoItemRequestDTO> items, MomoUserInfoDTO userInfo)
        {
            var accessKey = _config.Get(MomoSettings.AccessKey);
            var secretKey = _config.Get(MomoSettings.SecretKey);

            var dto = new MomoCollectionLinkRequestDTO
            {
                PartnerCode = _config.Get(MomoSettings.PartnerCode),
                PartnerName = _config.Get(MomoSettings.PartnerName),
                StoreId = _config.Get(MomoSettings.StoreId),
                RequestId = Guid.NewGuid().ToString(),
                Amount = amount,
                OrderId = orderId.ToString(),
                Items = items,
                UserInfo = userInfo
            };

            var rawSignature = $"accessKey={accessKey}&amount={dto.Amount}&extraData={dto.ExtraData}&ipnUrl={dto.IpnUrl}" +
                $"&orderId={dto.OrderId}&orderInfo={dto.OrderInfo}&partnerCode={dto.PartnerCode}&redirectUrl={dto.RedirectUrl}" +
                $"&requestId={dto.RequestId}&requestType={dto.RequestType}";

            dto.Signature = GetMomoSignature(rawSignature, secretKey);

            StringContent httpContent = new StringContent(JsonSerializer.Serialize(dto), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://test-payment.momo.vn/v2/gateway/api/create", httpContent);
            
            var body = response.Content.ReadAsStringAsync().Result;

            dynamic bodyJson = JToken.Parse(body);

            return new Dictionary<string, string>
            {
                {"WebLink", bodyJson.payUrl },
                {"DeepLink", bodyJson.deepLink }
            };
        }

        private string GetMomoSignature(string text, string key)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
