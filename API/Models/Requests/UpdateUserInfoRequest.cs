using AutoMapper.Configuration.Annotations;
using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models.Requests
{
    public class UpdateUserInfoRequest : SendOtpRequest
    {
        public UpdateUserInfoRequest() {}

        public UpdateUserInfoRequest(string name, Users.Genders gender, DateTimeOffset dateOfBirth, IFormFile avatar, 
            string registration, RegistrationTypes registrationTypes, OtpTypes otpTypes) 
            : base(registration, registrationTypes, otpTypes)
        {
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Avatar = avatar;
        }

        public string Name { get; set; } = string.Empty;
        public Users.Genders Gender { get; set; } = 0;
        public DateTimeOffset? DateOfBirth { get; set; } = null;
        public IFormFile? Avatar { get; set; } = null!;
    }

    public static class UpdateUserInfoRequestParsing
    {
        public static UpdateUserInfoRequest ToGeneric(this UpdateBookerInfoRequest x)
        {
            return new()
            {
                Name = x.Name,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                Avatar = x.Avatar,
                Registration = x.Gmail,
                RegistrationTypes = RegistrationTypes.Gmail,
                OtpTypes = x.OtpTypes
            };
        }

        public static UpdateUserInfoRequest ToGeneric(this UpdateDriverInfoRequest x)
        {
            return new()
            {
                Name = x.Name,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                Avatar = x.Avatar,
                Registration = x.PhoneNumber,
                RegistrationTypes = RegistrationTypes.Phone,
                OtpTypes = x.OtpTypes
            };
        }
    }

    public class UpdateBookerInfoRequest : SendGmailOtpRequest
    {
        [Required]
        [MaxLength(30, ErrorMessage = "The Name field has max length is 30 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range((int)Users.Genders.Female, (int)Users.Genders.Male, ErrorMessage = "The Gender field has value 0 for female or 1 for male.")]
        public Users.Genders Gender { get; set; } = 0;

        public DateTimeOffset? DateOfBirth { get; set; } = null;
        
        public IFormFile? Avatar { get; set; } = null!;
    }

    public class UpdateDriverInfoRequest : SendPhoneOtpRequest
    {
        [Required]
        [MaxLength(30, ErrorMessage = "The Name field has max length is 30 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range((int)Users.Genders.Female, (int)Users.Genders.Male, ErrorMessage = "The Gender field has value 0 for female or 1 for male.")]
        public Users.Genders Gender { get; set; } = 0;
        public DateTimeOffset? DateOfBirth { get; set; } = null;
        public IFormFile? Avatar { get; set; } = null!;
    }
}
