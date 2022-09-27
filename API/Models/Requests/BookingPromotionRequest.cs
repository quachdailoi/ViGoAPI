using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace API.Models.Requests
{
    public class BookingPromotionRequest
    {
        [IntegerValidator(MinValue = 1, MaxValue = 300, ExcludeRange = true)]
        public int? TotalTickets { get; set; } 
        public double? TotalPrice { get; set; }
        public PaymentMethods? PaymentMethods { get; set; }
        public VehicleTypes.Type? VehicleTypes { get; set; }
    }
}
