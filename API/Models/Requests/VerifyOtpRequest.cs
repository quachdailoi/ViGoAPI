using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class VerifyOtpRequest : SendOtpRequest
    {
        public VerifyOtpRequest() {}

        public VerifyOtpRequest(string OTP, string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes) 
            : base(registration, registrationTypes, otpTypes)
        {
            this.OTP = OTP;
        }

        [Required]
        public string OTP { get; set; } = string.Empty;
    }

    public static class VerifyOtpRequestParsing
    {
        public static VerifyOtpRequest ToGeneric(this VerifyPhoneOtpRequest x)
        {
            return new()
            {
                OTP = x.OTP,
                Registration = x.PhoneNumber,
                RegistrationTypes = RegistrationTypes.Phone,
                OtpTypes = x.OtpTypes
            };
        }

        public static VerifyOtpRequest ToGeneric(this VerifyGmailOtpRequest x)
        {
            return new()
            {
                OTP = x.OTP,
                Registration = x.Gmail,
                RegistrationTypes = RegistrationTypes.Gmail,
                OtpTypes = x.OtpTypes
            };
        }
    }

    public class VerifyPhoneOtpRequest : SendPhoneOtpRequest
    {
        [Required, MaxLength(6, ErrorMessage = "Otp must be a string with 6 digits.")]
        public string OTP { get; set; } = string.Empty;
    }

    public class VerifyGmailOtpRequest : SendGmailOtpRequest
    {
        [Required, MaxLength(6, ErrorMessage = "Otp must be a string with 6 digits.")]
        public string OTP { get; set; } = string.Empty;
    }
}
