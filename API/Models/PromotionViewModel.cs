using API.Extensions;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class PromotionViewModel
    {
        public int Quantity { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string? FilePath { get; set; } = string.Empty;
        public bool Available { get; set; } = true;
        public DateTimeOffset? ValidFrom { get; set; } = null;
        public DateTimeOffset? ValidUntil { get; set; } = null;
    }

    public class AdminPromotionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string? FilePath { get; set; } = string.Empty;
        public double DiscountPercentage { get; set; }
        public double MaxDecrease { get; set; }
        public Promotions.Types Type { get; set; }
        public Promotions.Status Status { get; set; }
        public PromotionConditionViewModel PromotionCondition { get; set; }
    }

    public class PromotionConditionViewModel
    {
        public int? TotalUsage { get; set; } = null;
        public int? UsagePerUser { get; set; } = null;
        public float? MinTotalPrice { get; set; } = null;
        public int? MinTickets { get; set; } = null;
        public Payments.PaymentMethods? PaymentMethods { get; set; } = null;
        public VehicleTypes.Type? VehicleTypes { get; set; } = null;
        [JsonIgnore]
        public DateTimeOffset? ValidFromData { get; set; } = null;
        [JsonIgnore]
        public DateTimeOffset? ValidUntilData { get; set; } = null;
        public string? ValidFrom { get => ValidFromData.HasValue ? ValidFromData.Value.ToFormatString() : null; }
        public string? ValidUntil { get => ValidUntilData.HasValue ? ValidUntilData.Value.ToFormatString() : null; }
    }
}
