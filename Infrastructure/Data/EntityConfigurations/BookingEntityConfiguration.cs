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
    public class BookingEntityConfiguration : BaseEntityConfiguration<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            base.Configure(builder);

            builder.ToTable("bookings");

            builder.Property(e => e.Time)
                .IsRequired()
                .HasColumnName("time");

            builder.Property(e => e.TotalPrice)
                .IsRequired()
                .HasColumnName("total_price");

            builder.Property(e => e.DiscountPrice)
                .IsRequired()
                .HasColumnName("discount_price");

            builder.Property(e => e.Option)
                .HasColumnName("option");

            builder.Property(e => e.Type)
                .HasConversion<int>()
                .HasColumnName("type");

            builder.Property(e => e.Days)
                .HasColumnType("jsonb")
                .HasColumnName("days");

            builder.Property(e => e.IsShared)
                .HasDefaultValue(false)
                .HasColumnName("is_shared");

            builder.Property(e => e.StartAt)
                .HasColumnName("start_at");

            builder.Property(e => e.EndAt)
                .HasColumnName("end_at");

            builder.Property(e => e.From)
                .HasColumnType("jsonb")
                .HasColumnName("from");

            builder.Property(e => e.To)
                .HasColumnType("jsonb")
                .HasColumnName("to");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.Property(e => e.PromotionId)
                .HasColumnName("promotion_id");

            builder.Property(e => e.Status)
                .HasConversion<int>()
                .HasColumnName("status");

            builder.HasOne(e => e.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(e => e.UserId);
        }
    }
}
