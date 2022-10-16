using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.SignalR.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class PaymentsController : BaseController<PaymentsController>
    {

        [HttpPost("linkWallet")]
        public async Task<IActionResult> LinkWallet([FromQuery] LinkWalletRequest request)
        {
            var user = this.LoggedInUser;

            var response = new Response();

            switch (request.Type)
            {
                case AffiliateParties.PartyTypes.Momo:
                    var dto = new MomoLinkingWalletRequestDTO();

                    dto.partnerClientId = user.Id.ToString();
                    dto.ipnUrl = $"{GetControllerContextUri()}/ipn/momo/linkWallet";

                    response =
                        await AppServices.Payment.GenerateMomoLinkingWalletUrl(
                                dto,
                                successResponse: new()
                                {
                                    Message = "Get Momo link-wallet url successfully.",
                                    StatusCode = StatusCodes.Status200OK
                                },
                                errorResponse: new()
                                {
                                    StatusCode = StatusCodes.Status500InternalServerError
                                }
                            );
                    break;
                default: 
                    response = new Response
                    {
                        Message = "Not supported",
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                    break;
            }

            return ApiResult(response);
        }

        [ApiExplorerSettings(IgnoreApi = true)] // api for momo return result of transaction
        [HttpPost("ipn/momo/linkWallet")]
        [AllowAnonymous]
        public async Task<IActionResult> HandleBookingMomoPaymentIPN([FromBody] JsonElement request)
        {
            var dto = JsonSerializer.Deserialize<MomoLinkWalletNotificationRequest>(request.GetRawText());

            var rawSignature = $"amount={dto.amount}&" +
                    $"callbackToken={dto.callbackToken}&" +
                    $"extraData={dto.extraData}&" +
                    $"message={dto.message}&" +
                    $"orderId={dto.orderId}&" +
                    $"orderInfo={dto.orderInfo}&" +
                    $"orderType={dto.orderType}&" +
                    $"partnerClientId={dto.partnerClientId}" +
                    $"partnerCode={dto.partnerCode}&" +
                    $"payType={dto.payType}&" +
                    $"requestId={dto.requestId}&" +
                    $"responseTime={dto.responseTime}&" +
                    $"resultCode={dto.resultCode}&" +
                    $"transId={dto.transId}";

            var signature = AppServices.Payment.GetMomoSignature(rawSignature);
                if (dto.resultCode == (int)Payments.MomoStatusCodes.Successed)
                {
                    await AppServices.Payment.GetTokenUserMomoLinkingWallet(dto);
                }

            //if (signature == dto.signature)
            //{
            return NoContent();
        }
    }
}
