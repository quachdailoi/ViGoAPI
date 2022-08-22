﻿namespace API.Models.Requests
{
    public class UpdateUserInfoRequest : SendOtpRequest
    {
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
