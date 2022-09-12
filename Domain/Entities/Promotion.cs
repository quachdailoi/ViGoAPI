using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Promotion : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public int? FileId { get; set; }
        public double DiscountPercentage { get; set; }
        public double MaxDecrease { get; set; }
        public Promotions.Types Type { get; set; }
        public Promotions.Status Status { get; set; }

        public AppFile? File { get; set; }
        public List<Booking> Bookings { get; set; }
        public PromotionCondition PromotionCondition { get; set; }
        public List<PromotionUser> PromotionUsers { get; set; }
    }
}
