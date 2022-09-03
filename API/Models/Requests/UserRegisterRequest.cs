using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models.Requests
{
    public class UserRegisterRequest : VerifyOtpRequest
    {
        public UserRegisterRequest() {}

        public UserRegisterRequest(string optionalRegistration, RegistrationTypes optionalRegistrationTypes, string name, 
            string OTP, string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes) 
            : base(OTP, registration, registrationTypes, otpTypes)
        {
            OptionalRegistration = optionalRegistration;
            OptionalRegistrationTypes = optionalRegistrationTypes;
            Name = name;
        }

        public string OptionalRegistration { get; set; } = string.Empty;
        [JsonIgnore]
        public RegistrationTypes OptionalRegistrationTypes { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public static class UserRegisterRequestParsing
    {
        public static UserRegisterRequest ToGeneric(this BookerRegisterRequest x)
        {
            return new ()
            {
                OptionalRegistration = x.Gmail,
                OptionalRegistrationTypes = RegistrationTypes.Gmail,
                Name = x.Name,
                OTP = x.OTP,
                Registration = x.PhoneNumber,
                RegistrationTypes = RegistrationTypes.Phone,
                OtpTypes = x.OtpTypes
            };
        }
    }

    public class BookerRegisterRequest : VerifyPhoneOtpRequest
    {
        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Invalid gmail address.")]
        public string  Gmail { get; set; } = string.Empty;
        [Required, MaxLength(30, ErrorMessage = "Name has max length: 30")]
        public string Name { get; set; } = string.Empty;
    }
}
