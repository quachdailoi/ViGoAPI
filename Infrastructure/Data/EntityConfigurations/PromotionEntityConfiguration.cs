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
    public class PromotionEntityConfiguration : BaseEntityConfiguration<Promotion>
    {
        public override void Configure(EntityTypeBuilder<Promotion> builder)
        {
            base.Configure(builder);

            builder.ToTable("promotions");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("name");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("code");

            builder.Property(e => e.Details)
                .IsRequired()
                .HasColumnName("details");

            builder.Property(e => e.FileId)
                .HasColumnName("file_id");

            builder.Property(e => e.DiscountPercentage)
                .IsRequired()
                .HasColumnName("discount_percentage");

            builder.Property(e => e.MaxDecrease)
                .IsRequired()
                .HasColumnName("max_decrease");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("type");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("status");

            builder.HasOne(e => e.PromotionCondition)
                .WithOne(e => e.Promotion)
                .HasForeignKey<PromotionCondition>(e => e.PromotionId);
        }
    }
}
