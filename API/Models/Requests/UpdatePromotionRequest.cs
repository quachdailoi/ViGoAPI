using API.Extensions;
using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class UpdatePromotionRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double DiscountPercentage { get; set; }
        public double MaxDecrease { get; set; }
        public Promotions.Types Type { get; set; }
        public Promotions.Status Status { get; set; } = Promotions.Status.Available;

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
