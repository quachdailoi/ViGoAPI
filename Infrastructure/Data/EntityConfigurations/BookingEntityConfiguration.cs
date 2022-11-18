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

            //builder.Navigation(b => b.StartRouteStation.Station).AutoInclude();

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

            //builder.Property(e => e.Type)
            //    .HasConversion<int>()
            //    .HasColumnName("type");

            builder.Property(e => e.DayOfWeeks)
                .HasColumnType("integer[]")
                .HasColumnName("day_of_weeks");

            builder.Property(e => e.IsShared)
                .HasDefaultValue(false)
                .HasColumnName("is_shared");

            builder.Property(e => e.StartAt)
                .HasColumnName("start_at");

            builder.Property(e => e.EndAt)
                .HasColumnName("end_at");

            builder.Property(e => e.StartRouteStationId)
                .HasColumnName("start_route_station_id");

            builder.Property(e => e.EndRouteStationId)
                .HasColumnName("end_route_station_id");

            builder.Property(e => e.VehicleTypeId)
                .HasConversion<int>()
                .HasColumnName("vehicle_type_id");

            builder.Property(e => e.PaymentMethod)
                .HasColumnName("payment_method");

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

            builder.HasOne(e => e.VehicleType)
                .WithMany(v => v.Bookings)
                .HasForeignKey(e => e.VehicleTypeId)
                .IsRequired();

            builder.HasOne(x => x.StartRouteStation)
                .WithMany(s => s.StartRouteStationBookings)
                .HasForeignKey(e => e.StartRouteStationId);

            builder.HasOne(x => x.EndRouteStation)
                .WithMany(s => s.EndRouteStationBookings)
                .HasForeignKey(e => e.EndRouteStationId);
        }
    }
}
