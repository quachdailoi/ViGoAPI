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
using Domain.Shares.Enums;

namespace API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private const string MOMO_ENDPOINT = "https://test-payment.momo.vn/v2/gateway/api/create";
        private const string MOMO_REFUND_ENDPOINT = "https://test-payment.momo.vn/v2/gateway/api/refund";
        public PaymentService(IConfiguration config)
        {
            _client = new HttpClient();
            _config = config;
        }

        public async Task<string?> GenerateMomoPaymentUrl(MomoCollectionLinkRequestDTO dto)
        {
            dto.partnerCode = _config.Get(MomoSettings.PartnerCode);
            dto.partnerName = _config.Get(MomoSettings.PartnerName);
            dto.storeId = _config.Get(MomoSettings.StoreId);
            dto.requestId = Guid.NewGuid().ToString();

            var rawSignature = $"amount={dto.amount}&" +
                $"extraData={dto.extraData}&" +
                $"ipnUrl={dto.ipnUrl}&" +
                $"orderId={dto.orderId}&" +
                $"orderInfo={dto.orderInfo}&" +
                $"partnerCode={dto.partnerCode}&" +
                $"redirectUrl={dto.redirectUrl}&" +
                $"requestId={dto.requestId}&" +
                $"requestType={dto.requestType}";

            dto.signature = GetMomoSignature(rawSignature);

            StringContent httpContent = new(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(MOMO_ENDPOINT, httpContent);

            var body = await response.Content.ReadAsStringAsync();

            var bodyJson = JToken.Parse(body);

            var resultCode = bodyJson.Value<int>("resultCode");
            var message = bodyJson.Value<string>("message");

            if (resultCode != MomoStatusCodes.Successed) throw new Exception(message);

            return bodyJson.Value<string>("payUrl");
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

        public async Task<bool> MomoRefund(long transId, long amount, string description = "")
        {
            var dto = new MomoRefundDTO
            {
                partnerCode = _config.Get(MomoSettings.PartnerCode),
                orderId = Guid.NewGuid().ToString(),
                requestId = Guid.NewGuid().ToString(),
                amount = amount,
                transId = transId,
                description = description
            };

            var rawSignature = $"amount={dto.amount}&" +
                $"description={dto.description}&" +
                $"orderId={dto.orderId}&" +
                $"partnerCode={dto.partnerCode}&" +
                $"requestId={dto.requestId}&" +
                $"transId={dto.transId}";

            dto.signature = GetMomoSignature(rawSignature);

            StringContent httpContent = new(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(MOMO_REFUND_ENDPOINT, httpContent);

            var body = await response.Content.ReadAsStringAsync();

            var bodyJson = JToken.Parse(body);

            var resultCode = bodyJson.Value<int>("resultCode");

            return resultCode == MomoStatusCodes.Successed;
        }
    }
}
