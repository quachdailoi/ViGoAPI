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
    public class VehicleEntityConfiguration : BaseEntityConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);

            builder.ToTable("vehicles");

            builder.Property(e => e.Code)
                .HasColumnName("code");

            builder.Property(e => e.Name)
                .HasColumnName("name");

            builder.Property(e => e.LicensePlate)
                .HasColumnName("license_plate");

            builder.Property(e => e.VehicleTypeId)
                .HasConversion<int>()
                .HasColumnName("vehicle_type_id");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.HasIndex(e => e.Code)
                .IsUnique();

            builder.HasOne(e => e.VehicleType)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(e => e.VehicleTypeId)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithOne(u => u.Vehicle)
                .HasForeignKey<Vehicle>(e => e.UserId);
        }
    }
}
