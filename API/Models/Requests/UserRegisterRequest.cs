using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models.Requests
{
    public class UserRegisterRequest : VerifyOtpRequest
    {
        public string OptionalRegistration { get; set; } = string.Empty;
        [JsonIgnore]
        public RegistrationTypes OptionalRegistrationTypes { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}