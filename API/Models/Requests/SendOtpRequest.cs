using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models.Requests
{
    public class SendOtpRequest : OtpTypesModel
    {
        public SendOtpRequest()
        {
        }

        public SendOtpRequest(string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes)
        {
            Registration = registration;
            RegistrationTypes = registrationTypes;
            OtpTypes = otpTypes;
        }

        public string Registration { get; set; } = string.Empty;

        [JsonIgnore]
        public RegistrationTypes RegistrationTypes = RegistrationTypes.Phone; //default
    }

    public static class SendOtpResponseParsing
    {
        public static SendOtpRequest ToGeneric(this SendPhoneOtpRequest request)
        {
            return new(request.PhoneNumber, RegistrationTypes.Phone, request.OtpTypes);
        }

        public static SendOtpRequest ToGeneric(this SendGmailOtpRequest request)
        {
            return new(request.Gmail, RegistrationTypes.Gmail, request.OtpTypes);
        }
    }

    public class SendPhoneOtpRequest : OtpTypesModel
    {
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class SendGmailOtpRequest : OtpTypesModel
    {
        [EmailAddress(ErrorMessage = "Invalid gmail address.")]
        [Required]
        public string Gmail { get; set; } = string.Empty;
    }

    public class OtpTypesModel
    {
        [JsonIgnore]
        public OtpTypes OtpTypes = OtpTypes.LoginOTP; // default
    }
}
