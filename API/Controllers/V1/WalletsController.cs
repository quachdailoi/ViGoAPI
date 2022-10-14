﻿using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.SignalR.Constract;
using API.Utils;
using AutoMapper;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    public class WalletsController : BaseController<WalletsController>
    {
        private readonly IMapper _mapper;
        private readonly ISignalRService _signalRService;

        public WalletsController(IMapper mapper, ISignalRService signalRService)
        {
            _mapper = mapper;
            _signalRService = signalRService;
        }

        [HttpPut("top-up")]
        public async Task<IActionResult> TopUpWallet([FromBody] WalletTopUpRequest request)
        {
            var user = this.LoggedInUser;

            var response = new Response();

            var paymentDto = new CollectionLinkRequestDTO();

            var transactionDto = _mapper.Map<WalletTransactionDTO>(request);

            switch (request.AffiliatePartyType)
            {
                case AffiliatePartyTypes.Types.Momo:
                    paymentDto = new MomoCollectionLinkRequestDTO
                    {
                        ipnUrl = $"{GetControllerContextUri()}/top-up/ipn/momo"
                    };
                    break;
                default:
                    return ApiResult(response
                        .SetMessage("Not supported.")
                        .SetStatusCode(StatusCodes.Status400BadRequest));
            }

            response =
                await AppServices.Wallet.HandleWalletTopUpRequest(
                    user.Id,
                    transactionDto,
                    paymentDto,
                    successResponse: new()
                    {
                        Message = "Get payment url for top up wallet successfully.",
                        StatusCode = StatusCodes.Status200OK
                    },
                    notSupportResponse: new()
                    {
                        Message = "Not supported.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    errorResponse: new()
                    {
                        Message = "Fail to get payment url.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    });


            return ApiResult(response);
        }

        [ApiExplorerSettings(IgnoreApi = true)] // api for momo return result of transaction
        [HttpPost("top-up/ipn/momo")]
        public async Task<IActionResult> HandleTopUpWalletMomoPaymentIPN([FromBody] JsonElement request)
        {
            var dto = JsonSerializer.Deserialize<MomoPaymentNotificationRequest>(request.GetRawText());

            var rawSignature = $"amount={dto.amount}&" +
                    $"extraData={dto.extraData}&" +
                    $"message={dto.message}&" +
                    $"orderId={dto.orderId}&" +
                    $"orderInfo={dto.orderInfo}&" +
                    $"orderType={dto.orderType}&" +
                    $"partnerCode={dto.partnerCode}&" +
                    $"payType={dto.payType}&" +
                    $"requestId={dto.requestId}&" +
                    $"responseTime={dto.responseTime}&" +
                    $"resultCode={dto.resultCode}&" +
                    $"transId={dto.transId}";

            var walletTransactionDto = Encryption.DecodeBase64<WalletTransactionDTO>(dto.extraData);

            

            if (dto.resultCode == (int)Payments.MomoStatusCodes.Successed)
            {
                walletTransactionDto.Status = WalletTransactions.Status.Success;
            }
            else
            {
                walletTransactionDto.Status = WalletTransactions.Status.Fail;
            }

            var wallet = await AppServices.Wallet.UpdateBalance(walletTransactionDto);

            if (wallet != null)
            {
                await _signalRService.SendToUserAsync(wallet.User.Code.ToString(), "TopUpResult",
                    new
                    {
                        TransactionCode = walletTransactionDto.Code,
                        Amount = walletTransactionDto.Amount,
                        IsSuccess = walletTransactionDto.Status == WalletTransactions.Status.Success
                    });
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetWallet()
        {
            var user = this.LoggedInUser;

            var response =
                await AppServices.Wallet.GetWallet(
                    user.Id,
                    successResponse: new()
                    {
                        Message = "Get wallet successfully.",
                        StatusCode = StatusCodes.Status200OK
                    },
                    errorResponse: new()
                    {
                        Message = "Fail to get wallet.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    });
            
            return ApiResult(response);
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetWalletTransations([FromQuery] PagingRequest pagingRequest)
        {
            var user = this.LoggedInUser;

            var response = 
                await AppServices.WalletTransaction.GetTransactions(
                    user.Id,
                    request: pagingRequest,
                    successResponse: new()
                    {
                        Message = "Get wallet transactions successfully.",
                        StatusCode= StatusCodes.Status200OK
                    });

            return ApiResult(response);
        }
    }
}
