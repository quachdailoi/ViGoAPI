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
using API.Utils;
using API.Models.Response;
using API.Models.Requests;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using API.Models.Responses.Payments.Momo;

namespace API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        private const string MOMO_ENDPOINT = "https://test-payment.momo.vn/v2/gateway/api/create";
        private const string MOMO_REFUND_ENDPOINT = "https://test-payment.momo.vn/v2/gateway/api/refund";
        private const string MOMO_TOKENIZATION_BIND = "https://test-payment.momo.vn/v2/gateway/api/tokenization/bind";
        
        public PaymentService(IConfiguration config, IMapper mapper, IUserService userService)
        {
            _client = new HttpClient();
            _config = config;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<GenerateMomoPaymentUrlResponse?> GenerateMomoPaymentUrl(MomoCollectionLinkRequestDTO dto)
        {
            dto.partnerCode = _config.Get(MomoSettings.PartnerCode);
            dto.partnerName = _config.Get(MomoSettings.PartnerName);
            dto.storeId = _config.Get(MomoSettings.StoreId);
            dto.requestId = Guid.NewGuid().ToString();
            dto.requestType = Payments.MomoRequestTypes.CaptureWallet.DisplayName();

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

            var obj = JToken.Parse(body).ToObject<GenerateMomoPaymentUrlResponse>();

            if (obj?.resultCode != (int)Payments.MomoStatusCodes.Successed) throw new Exception(obj?.message);

            return obj;
        }
        public async Task<Response> GenerateMomoLinkingWalletUrl(MomoLinkingWalletRequestDTO dto, Response successResponse, Response errorResponse)
        {
            dynamic paymentUrl;

            try
            {
                var response = await GenerateMomoLinkingWalletUrl(dto);
                paymentUrl = new
                {
                    PayUrl = response.payUrl,
                    Deeplink = response.deeplink,
                    DeeplinkMiniApp = response.deeplinkMiniApp
                };
            }
            catch(Exception ex)
            {
                return errorResponse.SetMessage(ex.Message);
            }

            return successResponse.SetData(new
            {
                PaymentUrl = paymentUrl
            });
        }
        public async Task<GenerateMomoLinkWalletUrlResponse?> GenerateMomoLinkingWalletUrl(MomoLinkingWalletRequestDTO dto)
        {
            dto.partnerCode = _config.Get(MomoSettings.PartnerCode);
            dto.partnerName = _config.Get(MomoSettings.PartnerName);
            dto.amount = 0;
            dto.requestId = Guid.NewGuid().ToString();
            dto.requestType = Payments.MomoRequestTypes.LinkWallet.DisplayName();

            var rawSignature = $"amount={dto.amount}&" +
                $"extraData={dto.extraData}&" +
                $"ipnUrl={dto.ipnUrl}&" +
                $"orderId={dto.orderId}&" +
                $"orderInfo={dto.orderInfo}&" +
                $"partnerClientId={dto.partnerClientId}&"+
                $"partnerCode={dto.partnerCode}&" +
                $"redirectUrl={dto.redirectUrl}&" +
                $"requestId={dto.requestId}&" +
                $"requestType={dto.requestType}";

            dto.signature = GetMomoSignature(rawSignature);

            StringContent httpContent = new(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(MOMO_ENDPOINT, httpContent);

            var body = await response.Content.ReadAsStringAsync();

            var obj = JToken.Parse(body).ToObject<GenerateMomoLinkWalletUrlResponse>();

            if (obj.resultCode != (int)Payments.MomoStatusCodes.Successed) throw new Exception(obj.message);

            return obj;
        } 

        public string GetMomoSignature(string text)
        {
            var accessKey = _config.Get(MomoSettings.AccessKey);
            var secretKey = _config.Get(MomoSettings.SecretKey);

            var rawSignature = $"accessKey={accessKey}&{text}";

            return Encryption.HashSHA256(rawSignature, secretKey);
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

            return resultCode == (int)Payments.MomoStatusCodes.Successed;
        }

        public async Task<bool> GetTokenUserMomoLinkingWallet(MomoLinkWalletNotificationRequest request)
        {
            var dto = _mapper.Map<GetMomoTokenRequest>(request);

            var rawSignature = $"callbackToken={dto.callbackToken}&" +
                $"orderId={dto.orderId}&" +
                $"partnerClientId={dto.partnerClientId}&" +
                $"partnerCode={dto.partnerCode}&" +
                $"requestId={dto.requestId}";

            dto.signature = GetMomoSignature(rawSignature);

            StringContent httpContent = new(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(MOMO_TOKENIZATION_BIND, httpContent);

            var body = await response.Content.ReadAsStringAsync();

            var obj = JToken.Parse(body).ToObject<GetMomoTokenResponse>();

            if(obj.resultCode != (int)Payments.MomoStatusCodes.Successed) return false;

            var secretKey = _config.Get(MomoSettings.SecretKey);

            var decodeStr = Encryption.DecryptAES(obj.aesToken, secretKey);

            Console.WriteLine($"DecodeToken:::{decodeStr}");

            var user = await _userService.GetUserById(int.Parse(obj.partnerClientId)).FirstOrDefaultAsync();

            return true;
        }
    }
}
