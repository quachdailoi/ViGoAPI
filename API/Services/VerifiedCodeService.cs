using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;
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

        public Task<MessageResource?> SendPhoneOtp(string phoneNumber, out string otp)
        {
            otp = GenerateOtpCode(6);

            var message = $"Otp code from ViGo App: {otp}";

            return SendSMS(message, phoneNumber);
        }

        public Task<string?> SendGmailOtp(string gmail, out string otp)
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

            var mailSettings = configuration.GetSection("MailSettings").Get<MailSettings>();

            email.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
            email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;

            BodyBuilder builder = new();

            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            using SmtpClient smtp = new();

            try
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
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
            string fromPhoneNumber = configuration.GetSection("Twilio:PhoneNumber").Value;

            // get base on environment

            var accountSid = configuration.GetConfigByEnv("Twilio:TWILIO_ACCOUNT_SID");
            var authToken = configuration.GetConfigByEnv("Twilio:TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
                body: sms,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );
        }
            
        private async Task<Response> SaveCode(SendOtpRequest request, string otp)
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
            if (code == null)
            {
                return new(
                    StatusCode: StatusCodes.Status400BadRequest,
                    Message: "Send Code Fail - Please try again."
                );
            }

            return new Response(
                StatusCode: StatusCodes.Status200OK,
                Message: "Send Otp Successfully.",
                Data: otp
            );
        }

        private async Task<Response?> VerifyOtp(string otp, string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes, string errorMessage, int errorCode)
        {
            var code = await _unitOfWork.VerifiedCodes.GetVerifiedCode(otp, registration, registrationTypes, otpTypes).FirstOrDefaultAsync();

            if (code == null)
            {
                return new(
                    StatusCode: errorCode,
                    Message: errorMessage
                );
            }

            var minuteForExpired = int.Parse(configuration.GetSection("OTP:ExpiredTime").Value);

            DateTime validTime = code.CreatedAt.AddMinutes(minuteForExpired);

            if (DateTime.Compare(validTime, DateTime.UtcNow) < 0)
            {
                return new(
                    StatusCode: errorCode,
                    Message: errorMessage
                );
            }

            return null;
        }

        public Task<Response?> VerifyOtp(VerifyOtpRequest request, string errorMessage, int errorCode)
        {
            return VerifyOtp(request.OTP, request.Registration, request.RegistrationTypes, request.OtpTypes, errorMessage, errorCode);
        }

        public Task<Response?> VerifyOtp(UpdateRegistrationByOtpRequest request, string errorMessage, int errorCode)
        {
            return VerifyOtp(request.OTP, request.Registration, RegistrationTypes.Phone, OtpTypes.UpdateOTP, errorMessage, errorCode);
        }

        private async Task<bool> CheckValidTimeSendOtp(string registration, RegistrationTypes registrationType, OtpTypes codeType)
        {
            var code = await _unitOfWork.VerifiedCodes.GetVerifiedCode(registration, registrationType, codeType).FirstOrDefaultAsync();

            if (code == null)
            {
                return true;
            }

            var minuteForResend = int.Parse(configuration.GetSection("OTP:TimeResend").Value);

            DateTime timeToResend = code.CreatedAt.AddMinutes(minuteForResend);

            var now = DateTime.UtcNow;

            if (DateTime.Compare(timeToResend, now) > 0)
            {
                return false;
            }

            return true;
        }

        public async Task<Response?> CheckValidTimeSendOtp(SendOtpRequest request, string errorMessage, int errorCode)
        {
            var canResend = await CheckValidTimeSendOtp(request.Registration, request.RegistrationTypes, request.OtpTypes);

            if (!canResend) 
            {
                return new Response(
                    StatusCode: errorCode,
                    Message: errorMessage
                );
            }

            return null;
        }

        public async Task<Response> SendAndSaveOtpPhoneNumber(SendOtpRequest request, string errorMessage, int errorCode)
        {
            var messageResource = await SendPhoneOtp(request.Registration, out string otp);

            if (messageResource?.Status == MessageResource.StatusEnum.Failed)
            {
                return new Response(
                    StatusCode: errorCode,
                    Message: errorMessage
                );
            }

            return await SaveCode(request, otp);
        }

        public async Task<Response> SendAndSaveOtpGmail(SendOtpRequest request, string errorMessage, int errorCode)
        {
            var mailResponse = await SendGmailOtp(request.Registration, out string otp);

            if (mailResponse == null || !mailResponse.Contains("2.0.0"))
            {
                return new Response(
                    StatusCode: errorCode,
                    Message: errorMessage
                );
            }

            return await SaveCode(request, otp);
        }
    }
}
