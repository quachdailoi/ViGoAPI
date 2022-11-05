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
    public class PricingEntityConfiguration : BaseEntityConfiguration<Pricing>
    {
        public override void Configure(EntityTypeBuilder<Pricing> builder)
        {
            base.Configure(builder);

            builder.ToTable("pricings");

            builder.Property(e => e.Code)
                .HasColumnName("code");

            builder.Property(e => e.LowerBound)
                .HasColumnName("lower_bound");

            builder.Property(e => e.UpperBound)
                .HasColumnName("upper_bound");

            builder.Property(e => e.Discount)
                .HasColumnName("discount");

            builder.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}
