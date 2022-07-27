using API.Models.Requests;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace API.Services
{
    public class VerifiedCodeService : IVerifiedCodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private static Random random = new Random();

        public VerifiedCodeService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.configuration = configuration;
        }

        private string GenerateOtpCode(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<Tuple<MessageResource, string>> SendPhoneOtp(string phoneNumber)
        {
            var otp = GenerateOtpCode(6);

            var message = $"Otp code from ViGo App: {otp}";

            var msgResource = await SendSMS(message, phoneNumber);

            return Tuple.Create(msgResource, otp);
        }

        public Task<string> SendGmailOtp(Account account)
        {
            return null;
        }

        private async Task<MessageResource> SendSMS(string sms, string toPhoneNumber)
        {
            string fromPhoneNumber = configuration.GetSection("Twilio:PhoneNumber").Value;

            string accountSid = configuration.GetSection("Twilio:TWILIO_ACCOUNT_SID").Value;
            string authToken = configuration.GetSection("Twilio:TWILIO_AUTH_TOKEN").Value;

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                body: sms,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );

            return message;
        }

        public async Task<VerifiedCode> SaveCode(string code, string registration, int registrationType, int codeType)
        {
            VerifiedCode verifiedCode = new()
            {
                RegistrationType = registrationType,
                Registration = registration,
                Code = code,
                ExpiredTime = DateTime.UtcNow.AddMinutes(5),
                Type = codeType,
            };

            return await _unitOfWork.VerifiedCodes.CreateVerifiedCode(verifiedCode);
        }

        public async Task<bool> CheckValidTimeSendOtp(string registration, int registrationType, int codeType)
        {
            var code = await _unitOfWork.VerifiedCodes.GetVerifiedCode(registration, registrationType, codeType).FirstOrDefaultAsync();
            
            if (code == null)
            {
                return true;
            }
            
            var minuteForResend = int.Parse(configuration.GetSection("OTP:TimeResend").Value);

            DateTime timeToResend = code.CreatedAt.AddMinutes(minuteForResend);

            if (DateTime.Compare(timeToResend, DateTime.UtcNow) < 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> CheckPhoneLoginByOtp(string otp, string registration, int registrationType, int codeType)
        {
            var code = await _unitOfWork.VerifiedCodes.GetVerifiedCode(otp, registration, registrationType, codeType).FirstOrDefaultAsync();

            var minuteForExpired = int.Parse(configuration.GetSection("OTP:ExpiredTime").Value);

            DateTime validTime = code.CreatedAt.AddMinutes(minuteForExpired);

            if (DateTime.Compare(validTime, DateTime.UtcNow) < 0)
            {
                return false;
            }

            return true;
        }
    }
}
