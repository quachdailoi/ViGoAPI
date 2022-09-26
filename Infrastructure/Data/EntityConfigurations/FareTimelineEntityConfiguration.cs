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
    public class FareTimelineEntityConfiguration : BaseEntityConfiguration<FareTimeline>
    {
        public override void Configure(EntityTypeBuilder<FareTimeline> builder)
        {
            base.Configure(builder);

            builder.ToTable("fare_timelines");

            builder.Property(e => e.StartTime)
                .HasColumnName("start_time");

            builder.Property(e => e.EndTime)
                .HasColumnName("end_time");

            builder.Property(e => e.ExtraFeePerKm)
                .HasColumnName("extra_fee_per_km");

            builder.Property(e => e.FareId)
                .IsRequired()
                .HasColumnName("fare_id");

            builder.HasOne(e => e.Fare)
                .WithMany(f => f.FareTimelines)
                .HasForeignKey(e => e.FareId)
                .IsRequired();
        }
    }
}
