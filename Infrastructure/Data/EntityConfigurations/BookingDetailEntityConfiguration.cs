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
    public class BookingDetailEntityConfiguration : BaseEntityConfiguration<BookingDetail>
    {
        public override void Configure(EntityTypeBuilder<BookingDetail> builder)
        {
            base.Configure(builder);

            builder.ToTable("booking_details");

            builder.Property(e => e.Rating)
                .HasColumnName("rating");

            builder.Property(e => e.FeedBack)
                .HasMaxLength(2000)
                .HasColumnName("feedback");

            builder.Property(e => e.Date)
                .IsRequired()
                .HasColumnName("date");

            builder.Property(e => e.Price)
                .IsRequired()
                .HasColumnName("price");

            builder.Property(e => e.DiscountPrice)
                .HasDefaultValue(0)
                .HasColumnName("discount_price");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("status");

            builder.Property(e => e.BookingId)
                .IsRequired()
                .HasColumnName("booking_id");

            builder.Property(e => e.MessageRoomId)
                .HasColumnName("message_room_id");

            builder.HasOne(e => e.Booking)
                .WithMany(b => b.BookingDetails)
                .HasForeignKey(e => e.BookingId);
        }
    }
}
