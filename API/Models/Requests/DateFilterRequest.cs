using API.Extensions;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace API.Models.Requests
{
    public class DateFilterRequest
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }

        public DateOnly FromDateParsed() => DateTimeExtensions.ParseExactDateOnly(FromDate); 
        public DateOnly ToDateParsed() => DateTimeExtensions.ParseExactDateOnly(ToDate);
    }
}
