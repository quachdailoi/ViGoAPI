using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfigurations
{
    public class SettingEntityConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("settings");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Key)
                .IsRequired()
                .HasColumnName("key");

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnName("value");

            builder.Property(e => e.TypeId)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("type_id");

            builder.Property(e => e.DataTypeId)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("data_type_id");

            builder.Property(e => e.DataUnitId)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("data_unit_id");

            builder.HasOne(e => e.Type)
                .WithMany(b => b.Settings)
                .HasForeignKey(e => e.TypeId);

            builder.HasOne(e => e.DataType)
                .WithMany(b => b.Settings)
                .HasForeignKey(e => e.DataTypeId);

            builder.HasOne(e => e.DataUnit)
                .WithMany(b => b.Settings)
                .HasForeignKey(e => e.DataUnitId);

            builder.HasIndex(e => e.Key)
                .IsUnique();
        }
    }
}
