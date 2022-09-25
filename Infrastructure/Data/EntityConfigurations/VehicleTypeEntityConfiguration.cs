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
    public class VehicleTypeEntityConfiguration : BaseEntityConfiguration<VehicleType>
    {
        public override void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            base.Configure(builder);

            builder.ToTable("vehicle_types");

            builder.Property(e => e.Code)
                .HasColumnName("code");

            builder.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(e => e.Slot)
                .HasColumnName("slot")
                .IsRequired();

            builder.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}
