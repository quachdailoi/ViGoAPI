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

            builder.Property(e => e.Code)
                .IsRequired()
                .HasDefaultValue(Guid.NewGuid())
                .HasColumnName("code");

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

            builder.Property(e => e.IsShared)
                .HasDefaultValue(false)
                .HasColumnName("is_shared");

            builder.Property(e => e.StartAt)
                .HasColumnName("start_at");

            builder.Property(e => e.EndAt)
                .HasColumnName("end_at");

            builder.Property(e => e.StartStationCode)
                .HasColumnName("start_station_code");

            builder.Property(e => e.EndStationCode)
                .HasColumnName("end_station_code");

            builder.Property(e => e.VehicleTypeId)
                .HasColumnName("vehicle_type_id");

            builder.Property(e => e.PaymentMethod)
                .HasColumnName("payment_method");

            builder.Property(e => e.RouteId)
                .HasColumnName("route_id");

            builder.Property(e => e.Distance)
                .IsRequired()
                .HasColumnName("distance");

            builder.Property(e => e.Duration)
                .IsRequired()
                .HasColumnName("duration");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.Property(e => e.PromotionId)
                .HasColumnName("promotion_id");

            builder.Property(e => e.Status)
                .HasConversion<int>()
                .HasColumnName("status");

            builder.HasIndex(e => e.Code).IsUnique();

            builder.HasOne(e => e.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Promotion)
                .WithMany(p => p.Bookings)
                .HasForeignKey(e => e.PromotionId);

            builder.HasOne(e => e.Route)
                .WithMany(route => route.Bookings)
                .HasForeignKey(e => e.RouteId)
                .IsRequired();

            builder.HasOne(e => e.VehicleType)
                .WithMany(v => v.Bookings)
                .HasForeignKey(e => e.VehicleTypeId)
                .IsRequired();


            // config for virtual relationship
            builder.HasOne(x => x.StartStation)
                .WithMany(s => s.StartStationBookings)
                .HasForeignKey(e => e.StartStationCode)
                .HasPrincipalKey(s => s.Code);

            builder.HasOne(x => x.EndStation)
                .WithMany(s => s.EndStationBookings)
                .HasForeignKey(e => e.EndStationCode)
                .HasPrincipalKey(s => s.Code);
        }
    }
}
