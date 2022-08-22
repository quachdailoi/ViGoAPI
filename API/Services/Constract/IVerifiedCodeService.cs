using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;
using Twilio.Rest.Api.V2010.Account;

namespace API.Services.Constract
{
    public interface IVerifiedCodeService
    {
        Task<Response?> VerifyOtp(VerifyOtpRequest request, string errorMessage, int errorCode);
        Task<Response?> VerifyOtp(UpdateRegistrationByOtpRequest request, string errorMessage, int errorCode);

        Task<Response?> CheckValidTimeSendOtp(SendOtpRequest request, string errorMessage, int errorCode);
        Task<Response> SendAndSaveOtp(SendOtpRequest request, string errorMessage, int errorCode);
    }
}
