using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses.Payments.Momo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Constract
{
    public interface IPaymentService
    { 
        Task<GenerateMomoPaymentUrlResponse?> GenerateMomoPaymentUrl(MomoCollectionLinkRequestDTO dto);
        Task<GenerateMomoLinkWalletUrlResponse?> GenerateMomoLinkingWalletUrl(MomoLinkingWalletRequestDTO dto);
        Task<Response> GenerateMomoLinkingWalletUrl(MomoLinkingWalletRequestDTO dto, Response successResponse, Response errorResponse);
        Task<bool> GetTokenUserMomoLinkingWallet(MomoLinkWalletNotificationRequest request);
        Task<bool> MomoRefund(long transId, long amount,string description = "");
        string GetMomoSignature(string text);
    }
}
