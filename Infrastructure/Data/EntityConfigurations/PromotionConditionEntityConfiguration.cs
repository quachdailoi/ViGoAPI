using Domain.Entities;
using Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfigurations
{
    public class PromotionConditionEntityConfiguration : BaseEntityConfiguration<PromotionCondition>
    {
        public override void Configure(EntityTypeBuilder<PromotionCondition> builder)
        {
            base.Configure(builder);

            builder.ToTable("promotion_conditions");

            builder.Property(e => e.PromotionId)
                .HasColumnName("promotion_id");

            builder.Property(e => e.TotalUsage)
                .HasColumnName("total_usage");

            builder.Property(e => e.UsagePerUser)
                .HasColumnName("usage_per_user");

            builder.Property(e => e.ValidFrom)
                .HasColumnName("valid_from");

            builder.Property(e => e.ValidUntil)
                .HasColumnName("valid_until");

            builder.Property(e => e.MinTotalPrice)
                .HasColumnName("min_total_price");

            builder.Property(e => e.MinTickets)
                .HasColumnName("min_tickets");

            builder.Property(e => e.PaymentMethods)
                .HasConversion<int>()
                .HasColumnName("payment_methods");

            builder.Property(e => e.VehicleTypes)
                .HasConversion<int>()
                .HasColumnName("vehicle_types");
        }
    }
}
