using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfigurations
{
    public class RouteRoutineEntityConfiguration : Base.BaseEntityConfiguration<RouteRoutine>
    {
        public override void Configure(EntityTypeBuilder<RouteRoutine> builder)
        {
            base.Configure(builder);

            builder.ToTable("route_routines");

            builder.Property(e => e.RouteId)
                .IsRequired()
                .HasColumnName("route_id");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.StartAt)
                .IsRequired()
                .HasColumnName("start_at");

            builder.Property(e => e.EndAt)
                .IsRequired()
                .HasColumnName("end_at");

            builder.Property(e => e.StartTime)
                .IsRequired()
                .HasColumnName("start_time");

            builder.Property(e => e.EndTime)
                .IsRequired()
                .HasColumnName("end_time");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("status")
                .HasDefaultValue(RouteRoutines.Status.Active);

            builder.HasOne(x => x.Route)
                .WithMany(x => x.RouteRoutines)
                .HasForeignKey(x => x.RouteId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.RouteRoutines)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}
