using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class RefundItemDTO
    {
        public Guid Code { get; set; }
        public double? Amount { get; set; }
        public RefundItems.Types Type { get; set; } = RefundItems.Types.Booking;
    }
}
