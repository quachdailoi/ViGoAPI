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
    public class LicenseTypeEntityConfiguration : IEntityTypeConfiguration<LicenseType>
    {
        public void Configure(EntityTypeBuilder<LicenseType> builder)
        {
            builder.ToTable("license_types");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            builder.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}
