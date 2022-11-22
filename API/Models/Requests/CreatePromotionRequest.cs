using API.Extensions;
using Domain.Shares.Enums;
using Newtonsoft.Json;

namespace API.Models.Requests
{
    public class CreatePromotionRequest
    {
        public string Name { get; set; }
        public string? Code { get; set; } = null;
        public string Details { get; set; }
        public double DiscountPercentage { get; set; }
        public double MaxDecrease { get; set; }
        public Promotions.Types Type { get; set; }

        public int? TotalUsage { get; set; } = null;
        public int? UsagePerUser { get; set; } = null;
        public string? ValidFrom { get; set; } = null;
        public string? ValidUntil { get; set; } = null;
        public float? MinTotalPrice { get; set; } = null;
        public int? MinTickets { get; set; } = null;
        public Payments.PaymentMethods? PaymentMethods { get; set; } = null;
        public VehicleTypes.Type? VehicleTypes { get; set; } = null;
        public IFormFile? File { get; set; } = null;
        public DateTimeOffset? ValidFromParsed() => string.IsNullOrEmpty(ValidFrom) ? null : DateTimeExtensions.ParseExactDateTime(ValidFrom);
        public DateTimeOffset? ValidUntilParsed() => string.IsNullOrEmpty(ValidUntil) ? null : DateTimeExtensions.ParseExactDateTime(ValidUntil);
    }
}
