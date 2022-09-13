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
        private readonly IConfiguration _config;
        private static Random random = new Random();

        public VerifiedCodeService(
            IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _config = configuration;
        }

        private string GenerateOtpCode(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Task<MessageResource?> SendPhoneOtp(string phoneNumber, string otp)
        {
            var message = $"Otp code from ViGo App: {otp}";

            return SendSMS(message, phoneNumber);
        }

        private Task<string?> SendGmailOtp(string gmail, string otp)
        {
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

            var mailBoxAddress = new MailboxAddress(
                _config.Get(MailSettings.DisplayName),
                _config.Get(MailSettings.Mail)
            );

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
                smtp.Connect(_config.Get(MailSettings.Host), _config.Get<int>(MailSettings.Port), MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_config.Get(MailSettings.Mail), _config.Get(MailSettings.Password));
                return await smtp.SendAsync(email);
                //logger.LogInformation($"Send mail to:  {mailContent.To}");
            }
            catch (Exception)
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
            var fromPhoneNumber = _config.Get(TwilioSettings.PhoneNumber);

            // get base on environment

            var accountSid = _config.Get(TwilioSettings.AccountSID);
            var authToken = _config.Get(TwilioSettings.AuthToken);

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
                body: sms,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );
        }
            
        private async Task<Response> SaveCode(SendOtpRequest request, string otp, Response successResponse, Response errorResponse)
        {
            var minuteForExpired = int.Parse(_config.Get(TwilioSettings.ExpiredTime) ?? "0");
            VerifiedCode verifiedCode = new()
            {
                RegistrationType = request.RegistrationTypes,
                Registration = request.Registration,
                Code = otp,
                ExpiredTime = DateTimeOffset.Now.AddMinutes(minuteForExpired),
                Type = request.OtpTypes,
                Status = true
            };

            var code = await _unitOfWork.VerifiedCodes.CreateVerifiedCode(verifiedCode);
            if (code == null) return errorResponse;

            successResponse.Data = otp;
            return successResponse;
        }

        private async Task<Response?> VerifyOtp(string otp, string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes, Response wrongResponse, Response expiredResponse)
        {
            var code = await _unitOfWork.VerifiedCodes.GetVerifiedCode(otp, registration, registrationTypes, otpTypes).FirstOrDefaultAsync();

            if (code == null) return wrongResponse;

            var minuteForExpired = int.Parse(_config.Get(TwilioSettings.ExpiredTime) ?? "0");

            DateTimeOffset validTime = code.CreatedAt.AddMinutes(minuteForExpired);

            if (DateTimeOffset.Compare(validTime, DateTimeOffset.Now) < 0)
            {
                return expiredResponse;
            }

            // disable OTP
            await _unitOfWork.VerifiedCodes.DisableCode(code);

            return null;
        }

        public Task<Response?> VerifyOtp(VerifyOtpRequest request, Response wrongResponse, Response expiredResponse)
        {
            return VerifyOtp(request.OTP, request.Registration, request.RegistrationTypes, request.OtpTypes, wrongResponse, expiredResponse);
        }

        private async Task<bool> CheckValidTimeSendOtp(string registration, RegistrationTypes registrationType, OtpTypes codeType)
        {
            var code = await _unitOfWork.VerifiedCodes.GetVerifiedCode(registration, registrationType, codeType).FirstOrDefaultAsync();

            if (code == null)
            {
                return true;
            }

            var minuteForResend = int.Parse(_config.Get(TwilioSettings.TimeResend) ?? "0");

            DateTimeOffset timeToResend = code.CreatedAt.AddMinutes(minuteForResend);

            var now = DateTimeOffset.Now;

            if (DateTimeOffset.Compare(timeToResend, now) > 0)
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
            var otp = GenerateOtpCode(6);

            await _unitOfWork.CreateTransactionAsync();
            var saveCodeResponse = await SaveCode(request, otp, successResponse, errorResponse);
            if (!saveCodeResponse.Success)
            {
                await _unitOfWork.Rollback();
                return errorResponse;
            }

            var messageResource = await SendPhoneOtp(request.Registration, otp);

            if (messageResource?.Status == MessageResource.StatusEnum.Failed)
            {
                await _unitOfWork.Rollback();
                return errorResponse;
            }

            _unitOfWork.CommitAsync();
            return successResponse;
        }

        private async Task<Response> SendAndSaveOtpGmail(SendOtpRequest request, Response successResponse, Response errorResponse)
        {
            var otp = GenerateOtpCode(6);

            await _unitOfWork.CreateTransactionAsync();

            var saveCodeResponse = await SaveCode(request, otp, successResponse, errorResponse);
            if (!saveCodeResponse.Success)
            {
                await _unitOfWork.Rollback();
                return errorResponse;
            }

            var mailResponse = await SendGmailOtp(request.Registration, otp);

            if (mailResponse == null || !mailResponse.Contains("2.0.0"))
            {
                return errorResponse;
            }

            _unitOfWork.CommitAsync();
            return successResponse;
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
