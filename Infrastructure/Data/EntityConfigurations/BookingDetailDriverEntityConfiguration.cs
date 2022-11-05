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
    public class BookingDetailDriverEntityConfiguration : BaseEntityConfiguration<BookingDetailDriver>
    {
        public override void Configure(EntityTypeBuilder<BookingDetailDriver> builder)
        {
            base.Configure(builder);

            builder.ToTable("booking_detail_drivers");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            builder.Property(e => e.StartTime)
                .HasColumnName("start_time");

            builder.Property(e => e.EndTime)
                .HasColumnName("end_time");

            builder.Property(e => e.RouteRoutineId)
                .HasColumnName("route_routine_id")
                .IsRequired();

            builder.Property(e => e.BookingDetailId)
                .HasColumnName("booking_detail_id")
                .IsRequired();

            builder.Property(e => e.TripStatus)
                .HasColumnName("trip_status")
                .HasConversion<int>()
                .IsRequired();

            builder.HasOne(e => e.RouteRoutine)
                .WithMany(d => d.BookingDetailDrivers)
                .HasForeignKey(e => e.RouteRoutineId)
                .IsRequired();

            builder.HasOne(e => e.BookingDetail)
                .WithMany(b => b.BookingDetailDrivers)
                .HasForeignKey(e => e.BookingDetailId)
                .IsRequired();

            builder.HasIndex(e => new { e.RouteRoutineId, e.BookingDetailId })
                .IsUnique();
        }
    }
}
