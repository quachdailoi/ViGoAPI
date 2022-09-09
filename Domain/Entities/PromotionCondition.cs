using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PromotionCondition : BaseEntity
    {
        public int? PromotionId { get; set; } = null;
        public int? TotalUsage { get; set; } = null;
        public int? UsagePerUser { get; set; } = null;
        public DateTime? ValidFrom { get; set; } = null;
        public DateTime? ValidUntil { get; set; } = null;
        public float? MinTotal { get; set; } = null;
        public int? MinTicket { get; set; } = null;
        public PaymentMethod? PaymentMethod { get; set; } = null;

        public Promotion Promotion { get; set; }
        public List<PromotionUser> UserPromotionConditions { get; set; }
    }
}
