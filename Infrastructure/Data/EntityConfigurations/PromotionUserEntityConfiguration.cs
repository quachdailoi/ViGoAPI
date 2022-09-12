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
    public class PromotionUserEntityConfiguration : BaseEntityConfiguration<PromotionUser>
    {
        public override void Configure(EntityTypeBuilder<PromotionUser> builder)
        {
            base.Configure(builder);

            builder.ToTable("promotion_users");

            builder.Property(e => e.PromotionId)
                .IsRequired()
                .HasColumnName("promotion_id");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.Used)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName("used");

            builder.Property(e => e.ExpiredTime)
                .HasColumnName("expired_time");

            builder.HasOne(e => e.Promotion)
                .WithMany(e => e.PromotionUsers)
                .HasForeignKey(e => e.PromotionId)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e => e.PromotionUsers)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder
                .HasIndex(e => new { e.PromotionId, e.UserId })
                .IsUnique();
        }
    }
}
