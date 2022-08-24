using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;
using Twilio.Rest.Api.V2010.Account;

namespace API.Services.Constract
{
    public interface IVerifiedCodeService
    {
        Task<Response?> VerifyOtp(VerifyOtpRequest request, Response errorResponse);
        Task<Response?> CheckValidTimeSendOtp(SendOtpRequest request, Response errorResponse);
        Task<Response> SendAndSaveOtp(SendOtpRequest request, Response successResponse, Response errorResponse);
    }
}
