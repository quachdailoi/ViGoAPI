using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models.Requests
{
    public class SendOtpRequest
    {
        [Required]
        public string Registration { get; set; } = string.Empty;

        [JsonIgnore]
        public RegistrationTypes RegistrationTypes = RegistrationTypes.Phone; //default

        [JsonIgnore]
        public OtpTypes OtpTypes = OtpTypes.LoginOTP; // default
    }
}
