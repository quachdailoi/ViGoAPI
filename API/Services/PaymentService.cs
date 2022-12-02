using API.Extensions;
using API.Models.DTO;
using API.Models.SettingConfigs;
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
using API.Models.Responses.Payments.ZaloPay;

namespace API.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly HttpClient _client;
        private const string MOMO_ENDPOINT = "https://test-payment.momo.vn/v2/gateway/api/create";
        private const string MOMO_REFUND_ENDPOINT = "https://test-payment.momo.vn/v2/gateway/api/refund";
        private const string MOMO_TOKENIZATION_BIND = "https://test-payment.momo.vn/v2/gateway/api/tokenization/bind";

        private const string ZALOPAY_CREATE_ENDPOINT = "https://sb-openapi.zalopay.vn/v2/create";
        public PaymentService(IAppServices appServices) : base(appServices)
        {
            _client = new HttpClient();
        }

        public async Task<GenerateMomoPaymentUrlResponse?> GenerateMomoPaymentUrl(MomoCollectionLinkRequestDTO dto)
        {
            dto.partnerCode = Configuration.Get(MomoSettings.PartnerCode);
            dto.partnerName = Configuration.Get(MomoSettings.PartnerName);
            dto.storeId = Configuration.Get(MomoSettings.StoreId);
            dto.requestId = Guid.NewGuid().ToString();
            dto.requestType = Payments.MomoRequestTypes.CaptureWallet.DisplayName();
            dto.redirectUrl = Configuration.Get(MomoSettings.RedirectUrl);

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

            var obj = new GenerateMomoPaymentUrlResponse();

            try
            {
                obj = JToken.Parse(body).ToObject<GenerateMomoPaymentUrlResponse>();
            }
            catch
            {
                throw new Exception($"Pay by Momo - Momo server is unavailable");
            }

            if (obj.resultCode != (int)Payments.MomoStatusCodes.Successed) throw new Exception($"Pay by Momo - {obj.message}");

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
            dto.partnerCode = Configuration.Get(MomoSettings.PartnerCode);
            dto.partnerName = Configuration.Get(MomoSettings.PartnerName);
            dto.amount = 0;
            dto.requestId = Guid.NewGuid().ToString();
            dto.requestType = Payments.MomoRequestTypes.LinkWallet.DisplayName();
            dto.redirectUrl = Configuration.Get(MomoSettings.RedirectUrl);

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

            var obj = new GenerateMomoLinkWalletUrlResponse();

            try
            {
                obj = JToken.Parse(body).ToObject<GenerateMomoLinkWalletUrlResponse>();
            }
            catch
            {
                throw new Exception($"Linking Momo - Momo server is unavailable");
            }

            if (obj.resultCode != (int)Payments.MomoStatusCodes.Successed) throw new Exception($"Linking Momo - {obj.message}");

            return obj;
        } 

        public string GetMomoSignature(string text)
        {
            var accessKey = Configuration.Get(MomoSettings.AccessKey);
            var secretKey = Configuration.Get(MomoSettings.SecretKey);

            var rawSignature = $"accessKey={accessKey}&{text}";

            return Encryption.HashSHA256(rawSignature, secretKey);
        }

        public async Task<MomoRefundResponse> MomoRefund(long transId, long amount, string description = "")
        {
            var dto = new MomoRefundDTO
            {
                partnerCode = Configuration.Get(MomoSettings.PartnerCode),
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

            var obj = new MomoRefundResponse();

            try
            {
                obj = JToken.Parse(body).ToObject<MomoRefundResponse>();
            }
            catch
            {
                throw new Exception($"Refund Momo - Momo server is unavailable");
            }

            if (obj.resultCode != (int)Payments.MomoStatusCodes.Successed) throw new Exception($"Refund Momo - {obj.message}");

            return obj;
        }

        public async Task<bool> GetTokenUserMomoLinkingWallet(MomoLinkWalletNotificationRequest request)
        {
            var dto = Mapper.Map<GetMomoTokenRequest>(request);

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

            var secretKey = Configuration.Get(MomoSettings.SecretKey);

            var decodeStr = Encryption.DecryptAES(obj.aesToken, secretKey);

            Console.WriteLine($"DecodeToken:::{decodeStr}");

            var user = await AppServices.User.GetUserById(int.Parse(obj.partnerClientId)).FirstOrDefaultAsync();

            return true;
        }

        public async Task<GenerateZaloPayPaymentUrlResponse> GenerateZaloPaymentUrl(ZaloCollectionLinkRequestDTO dto)
        {
            var key = Configuration.Get(ZaloPaySettings.Key1);

            dto.app_id = Configuration.Get<int>(ZaloPaySettings.AppId);
            dto.raw_embed_data.redirecturl = Configuration.Get<string>(ZaloPaySettings.RedirectUrl);
            dto.mac = Encryption.HMACSHA256(dto.mac_data, key);


            StringContent httpContent = new(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(ZALOPAY_CREATE_ENDPOINT, httpContent);

            var body = await response.Content.ReadAsStringAsync();

            var obj = new GenerateZaloPayPaymentUrlResponse();

            try
            {
                obj = JToken.Parse(body).ToObject<GenerateZaloPayPaymentUrlResponse>();
            }
            catch
            {
                throw new Exception($"Pay by Zalo - Zalo server is unavailable");
            }

            Console.WriteLine(JsonConvert.SerializeObject(dto));

            return obj;
        }
    }
}
