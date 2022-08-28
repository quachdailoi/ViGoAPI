using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Settings;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace API.Services
{
    public class VerifiedCodeService : IVerifiedCodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MailSettings _mailSettings;
        private readonly TwilioSettings _twilioSettings;
        private static Random random = new Random();

        public VerifiedCodeService(
            IUnitOfWork unitOfWork, 
            IOptions<TwilioSettings> twilioSettings, 
            IOptions<MailSettings> mailSettings)
        {
            _unitOfWork = unitOfWork;
            _mailSettings = mailSettings.Value;
            _twilioSettings = twilioSettings.Value;
        }

        private string GenerateOtpCode(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Task<MessageResource?> SendPhoneOtp(string phoneNumber, out string otp)
        {
            otp = GenerateOtpCode(6);

            var message = $"Otp code from ViGo App: {otp}";

            return SendSMS(message, phoneNumber);
        }

        private Task<string?> SendGmailOtp(string gmail, out string otp)
        {
            otp = GenerateOtpCode(6);
            MailContent mailContent = new()
            {
                To = gmail,
                Subject = "Vigo App: Verify Email",
                Body = $"Otp code from ViGo App: {otp}"
            };
            return SendMail(mailContent);
        }

        private async Task<string?> SendMail(MailContent mailContent)
        {
            MimeMessage email = new();

            var mailBoxAddress = new MailboxAddress((string?)_mailSettings.Get("DisplayName"), (string?)_mailSettings.Get("Mail"));

            email.Sender = mailBoxAddress;
            email.From.Add(mailBoxAddress);
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;

            BodyBuilder builder = new();

            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            using SmtpClient smtp = new();

            try
            {
                smtp.Connect((string ?)_mailSettings.Get("Host"), (int?) _mailSettings.Get("Port") ?? 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate((string?)_mailSettings.Get("Mail"), (string?)_mailSettings.Get("Password"));
                return await smtp.SendAsync(email);
                //logger.LogInformation($"Send mail to:  {mailContent.To}");
            }
            catch (Exception e)
            {
                //logger.LogInformation($"Fail: Send mail to:  {mailContent.To}");
                //logger.LogError(e.Message);
            }
            finally
            {
                smtp.Disconnect(true);
            }    
            return null;
        }

        private Task<MessageResource?> SendSMS(string sms, string toPhoneNumber)
        {
            var fromPhoneNumber = (string?) _twilioSettings.Get("PhoneNumber");

            // get base on environment

            var accountSid = (string?) _twilioSettings.Get("AccountSID");
            var authToken = (string?) _twilioSettings.Get("AuthToken");

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
                body: sms,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );
        }
            
        private async Task<Response> SaveCode(SendOtpRequest request, string otp, Response successResponse, Response errorResponse)
        {
            VerifiedCode verifiedCode = new()
            {
                RegistrationType = request.RegistrationTypes,
                Registration = request.Registration,
                Code = otp,
                ExpiredTime = DateTime.UtcNow.AddMinutes(5),
                Type = request.OtpTypes,
            };

            var code = await _unitOfWork.VerifiedCodes.CreateVerifiedCode(verifiedCode);
            if (code == null) return errorResponse;

            successResponse.Data = otp;
            return successResponse;
        }

        private async Task<Response?> VerifyOtp(string otp, string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes, Response errorResponse)
        {
            var code = await _unitOfWork.VerifiedCodes.GetVerifiedCode(otp, registration, registrationTypes, otpTypes).FirstOrDefaultAsync();

            if (code == null)
            {
                return new(
                    StatusCode: errorResponse.StatusCode,
                    Message: errorResponse.Message
                );
            }

            var minuteForExpired = (int?) _twilioSettings.Get("ExpiredTime") ?? 0;

            DateTime validTime = code.CreatedAt.AddMinutes(minuteForExpired);

            if (DateTime.Compare(validTime, DateTime.UtcNow) < 0)
            {
                return new(
                    StatusCode: errorResponse.StatusCode,
                    Message: errorResponse.Message
                );
            }

            return null;
        }

        public Task<Response?> VerifyOtp(VerifyOtpRequest request, Response errorResponse)
        {
            return VerifyOtp(request.OTP, request.Registration, request.RegistrationTypes, request.OtpTypes, errorResponse);
        }

        private async Task<bool> CheckValidTimeSendOtp(string registration, RegistrationTypes registrationType, OtpTypes codeType)
        {
            var code = await _unitOfWork.VerifiedCodes.GetVerifiedCode(registration, registrationType, codeType).FirstOrDefaultAsync();

            if (code == null)
            {
                return true;
            }

            var minuteForResend = (int?) _twilioSettings.Get("TimeResend") ?? 0;

            DateTime timeToResend = code.CreatedAt.AddMinutes(minuteForResend);

            var now = DateTime.UtcNow;

            if (DateTime.Compare(timeToResend, now) > 0)
            {
                return false;
            }

            return true;
        }

        public async Task<Response?> CheckValidTimeSendOtp(SendOtpRequest request, Response response)
        {
            var canResend = await CheckValidTimeSendOtp(request.Registration, request.RegistrationTypes, request.OtpTypes);

            if (!canResend) 
            {
                return new Response(
                    StatusCode: response.StatusCode,
                    Message: response.Message
                );
            }

            return null;
        }

        private async Task<Response> SendAndSaveOtpPhoneNumber(SendOtpRequest request, Response successResponse, Response errorResponse)
        {
            var messageResource = await SendPhoneOtp(request.Registration, out string otp);

            if (messageResource?.Status == MessageResource.StatusEnum.Failed)
            {
                return new Response(
                    StatusCode: errorResponse.StatusCode,
                    Message: errorResponse.Message
                );
            }

            return await SaveCode(request, otp, successResponse, errorResponse);
        }

        private async Task<Response> SendAndSaveOtpGmail(SendOtpRequest request, Response successResponse, Response errorResponse)
        {
            var mailResponse = await SendGmailOtp(request.Registration, out string otp);

            if (mailResponse == null || !mailResponse.Contains("2.0.0"))
            {
                return new Response(
                    StatusCode: errorResponse.StatusCode,
                    Message: errorResponse.Message
                );
            }

            return await SaveCode(request, otp, successResponse, errorResponse);
        }

        public async Task<Response> SendAndSaveOtp(SendOtpRequest request, Response successResponse, Response errorResponse)
        {
            switch (request.RegistrationTypes)
            {
                case RegistrationTypes.Phone:
                    return await SendAndSaveOtpPhoneNumber(request, successResponse, errorResponse);
                case RegistrationTypes.Gmail:
                    return await SendAndSaveOtpGmail(request, successResponse, errorResponse);
                default:
                    return errorResponse;
            }
        }
    }
}
