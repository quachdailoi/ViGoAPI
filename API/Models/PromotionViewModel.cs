using Domain.Shares.Enums;

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
    }
}
