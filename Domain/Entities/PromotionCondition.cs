﻿using Domain.Entities.Base;
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
        public DateTimeOffset? ValidFrom { get; set; } = null;
        public DateTimeOffset? ValidUntil { get; set; } = null;
        public float? MinTotalPrice { get; set; } = null;
        public int? MinTickets { get; set; } = null;
        public Payments.PaymentMethods? PaymentMethods { get; set; } = null;
        public VehicleTypes.SpecificType? VehicleTypeId { get; set; } = null;

        public VehicleType? VehicleType { get; set; } = null;

        public Promotion? Promotion { get; set; }
        //public List<PromotionUser> PromotionUsers { get; set; }
    }
}
