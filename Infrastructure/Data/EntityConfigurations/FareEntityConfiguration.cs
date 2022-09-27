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
    public class FareEntityConfiguration : BaseEntityConfiguration<Fare>
    {
        public override void Configure(EntityTypeBuilder<Fare> builder)
        {
            base.Configure(builder);

            builder.ToTable("fares");

            builder.Property(e => e.BasePrice)
                .HasColumnName("base_price");

            builder.Property(e => e.PricePerKm)
                .HasColumnName("price_per_km");

            builder.Property(e => e.BaseDistance)
                .HasColumnName("base_distance");

            builder.Property(e => e.VehicleTypeId)
                .HasColumnName("vehicle_type_id");

            builder.HasOne(e => e.VehicleType)
                .WithOne(v => v.Fare)
                .HasForeignKey<Fare>(e => e.VehicleTypeId)
                .IsRequired();
        }
    }
}
