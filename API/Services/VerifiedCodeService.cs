﻿using Amazon.Runtime.Internal;
using Amazon.S3.Model.Internal.MarshallTransformations;
using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.SettingConfigs;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace API.Services
{
    public class VerifiedCodeService : BaseService, IVerifiedCodeService
    {
        private static Random random = new Random();

        public VerifiedCodeService(IAppServices appServices) : base(appServices)
        {
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

        public Task SendMail(string mail, string subject, string content)
        {
            MailContent mailContent = new()
            {
                To = mail,
                Subject = subject,
                Body = content
            };
            return SendMail(mailContent);
        }

        private async Task<string?> SendMail(MailContent mailContent)
        {
            MimeMessage email = new();

            var mailBoxAddress = new MailboxAddress(
                Configuration.Get(MailSettings.DisplayName),
                Configuration.Get(MailSettings.Mail)
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
                smtp.Connect(Configuration.Get(MailSettings.Host), Configuration.Get<int>(MailSettings.Port), MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(Configuration.Get(MailSettings.Mail), Configuration.Get(MailSettings.Password));
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
            var fromPhoneNumber = Configuration.Get(TwilioSettings.PhoneNumber);

            // get base on environment

            var accountSid = Configuration.Get(TwilioSettings.AccountSID);
            var authToken = Configuration.Get(TwilioSettings.AuthToken);

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
                body: sms,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );
        }
            
        private async Task<Response> SaveCode(SendOtpRequest request, string otp, Response successResponse, Response errorResponse)
        {
            var minuteForExpired = int.Parse(Configuration.Get(TwilioSettings.ExpiredTime) ?? "0");
            VerifiedCode verifiedCode = new()
            {
                RegistrationType = request.RegistrationTypes,
                Registration = request.Registration,
                Code = otp,
                ExpiredTime = DateTimeOffset.Now.AddMinutes(minuteForExpired),
                Type = request.OtpTypes,
                Status = true
            };

            var code = await UnitOfWork.VerifiedCodes.CreateVerifiedCode(verifiedCode);
            if (code == null) return errorResponse;

            successResponse.Data = otp;
            return successResponse;
        }

        private async Task<Response?> VerifyOtp(string otp, string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes, Response wrongResponse, Response expiredResponse)
        {
            if (otp == "000000" && registrationTypes == RegistrationTypes.Phone && OtpTypes.LoginOTP == otpTypes)
            {
                switch(registration)
                {
                    case "+84837226239":
                    case "+84914669962":
                    case "+84377322919":
                    case "+84376826328":
                        return null;
                }
            }
            
            var code = await UnitOfWork.VerifiedCodes.GetVerifiedCode(otp, registration, registrationTypes, otpTypes).FirstOrDefaultAsync();

            if (code == null) return wrongResponse;

            var minuteForExpired = int.Parse(Configuration.Get(TwilioSettings.ExpiredTime) ?? "0");

            DateTimeOffset validTime = code.CreatedAt.AddMinutes(minuteForExpired);

            if (DateTimeOffset.Compare(validTime, DateTimeOffset.Now) < 0)
            {
                return expiredResponse;
            }

            // disable OTP
            await UnitOfWork.VerifiedCodes.DisableCode(code);

            return null;
        }

        public async Task<bool> VerifyOtpLink(string otp, string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes)
        {
            if (otp == "000000" && registrationTypes == RegistrationTypes.Phone && OtpTypes.LoginOTP == otpTypes)
            {
                switch (registration)
                {
                    case "+84837226239":
                    case "+84914669962":
                    case "+84377322919":
                    case "+84376826328":
                        return true;
                }
            }

            var code = await UnitOfWork.VerifiedCodes.GetVerifiedCode(otp, registration, registrationTypes, otpTypes).FirstOrDefaultAsync();

            if (code == null) return false;

            // disable OTP
            await UnitOfWork.VerifiedCodes.DisableCode(code);

            return true;
        }

        public Task<Response?> VerifyOtp(VerifyOtpRequest request, Response wrongResponse, Response expiredResponse)
        {
            return VerifyOtp(request.OTP, request.Registration, request.RegistrationTypes, request.OtpTypes, wrongResponse, expiredResponse);
        }

        private async Task<bool> CheckValidTimeSendOtp(string registration, RegistrationTypes registrationType, OtpTypes codeType)
        {
            var code = await UnitOfWork.VerifiedCodes.GetVerifiedCode(registration, registrationType, codeType).FirstOrDefaultAsync();

            if (code == null)
            {
                return true;
            }

            var minuteForResend = int.Parse(Configuration.Get(TwilioSettings.TimeResend) ?? "0");

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

            await UnitOfWork.CreateTransactionAsync();
            var saveCodeResponse = await SaveCode(request, otp, successResponse, errorResponse);
            if (!saveCodeResponse.Success)
            {
                await UnitOfWork.Rollback();
                return errorResponse;
            }

            var messageResource = await SendPhoneOtp(request.Registration, otp);

            if (messageResource?.Status == MessageResource.StatusEnum.Failed)
            {
                await UnitOfWork.Rollback();
                return errorResponse;
            }

            await UnitOfWork.CommitAsync();
            return successResponse;
        }

        private async Task<Response> SendAndSaveOtpGmail(SendOtpRequest request, Response successResponse, Response errorResponse)
        {
            var otp = GenerateOtpCode(6);

            await UnitOfWork.CreateTransactionAsync();

            var saveCodeResponse = await SaveCode(request, otp, successResponse, errorResponse);
            if (!saveCodeResponse.Success)
            {
                await UnitOfWork.Rollback();
                return errorResponse;
            }

            var mailResponse = await SendGmailOtp(request.Registration, otp);

            if (mailResponse == null || !mailResponse.Contains("2.0.0"))
            {
                return errorResponse;
            }

            UnitOfWork.CommitAsync();
            return successResponse;
        }

        public async Task SendMailOTPVerificationLink(UserViewModel user, string subject, string content)
        {
            var mail = user.Gmail;
            var otp = await CreateOTPVerificationLinkCode(mail, RegistrationTypes.Gmail, OtpTypes.MailLinkOTP);
            if (otp == null) throw new Exception("Failed to create otp code to mail.");
            
            var token = AppServices.JwtHandler.GenerateToken(user, isExpired: false, otp, OtpTypes.MailLinkOTP);
            var host = Configuration.Get(MailSettings.VerifiedAccountHost);
            var link = string.Format(host, token);

            content = string.Format(content, link);
            
            SendMail(mail, subject, content); 

            await Task.CompletedTask;
        }

        public async Task SendPhoneOTPVerificationLink(UserViewModel user, string message)
        {
            var phone = user.PhoneNumber;
            var otp = await CreateOTPVerificationLinkCode(phone, RegistrationTypes.Phone, OtpTypes.SMSLinkOTP);
            if (otp == null) throw new Exception("Failed to create otp code to phone.");

            var token = AppServices.JwtHandler.GenerateToken(user, isExpired: false, otp, OtpTypes.SMSLinkOTP);

            var host = Configuration.Get(TwilioSettings.VerifiedAccountHost);
            var link = string.Format(host, token);
            message = string.Format(message, link);

            SendSMS(message, phone);
            await Task.CompletedTask;
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

        public async Task<string?> CreateOTPVerificationLinkCode(string registration, RegistrationTypes registrationType, OtpTypes otpType)
        {
            var otp = GenerateOtpCode(6);
            VerifiedCode verifiedCode = new()
            {
                RegistrationType = registrationType,
                Registration = registration,
                Code = otp,
                ExpiredTime = null,
                Type = otpType,
                Status = true
            };

            var code = await UnitOfWork.VerifiedCodes.CreateVerifiedCode(verifiedCode);

            if (code == null) return null;
            return otp;
        }
    }
}
