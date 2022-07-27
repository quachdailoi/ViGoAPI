using API.Models.Requests;
using Domain.Entities;
using Domain.Shares.Enums;
using Twilio.Rest.Api.V2010.Account;

namespace API.Services.Constract
{
    public interface IVerifiedCodeService
    {
        Task<Tuple<MessageResource, string>> SendPhoneOtp(string phoneNumber);
        Task<string> SendGmailOtp(Account account);
        Task<VerifiedCode> SaveCode(string code, string registration, int registrationType, int codeType);
        Task<bool> CheckValidTimeSendOtp(string registration, int registrationType, int codeType);
        Task<bool> CheckPhoneLoginByOtp(string otp, string registration, int registrationType, int codeType);
    }
}
