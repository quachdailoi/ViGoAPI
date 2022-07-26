﻿using API.Models;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;
using Twilio.Rest.Api.V2010.Account;

namespace API.Services.Constract
{
    public interface IVerifiedCodeService
    {
        Task<Response?> VerifyOtp(VerifyOtpRequest request, Response wrongResponse, Response expiredResponse);
        Task<Response?> CheckValidTimeSendOtp(SendOtpRequest request, Response errorResponse);
        Task<Response> SendAndSaveOtp(SendOtpRequest request, Response successResponse, Response errorResponse);
        Task SendMail(string mail, string subject, string content);
        Task SendMailOTPVerificationLink(UserViewModel user, string subject, string content);
        Task<string?> CreateOTPVerificationLinkCode(string registration, RegistrationTypes registrationType, OtpTypes otpType);
        Task SendPhoneOTPVerificationLink(UserViewModel user, string message);
        Task<bool> VerifyOtpLink(string otp, string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes);
    }
}
