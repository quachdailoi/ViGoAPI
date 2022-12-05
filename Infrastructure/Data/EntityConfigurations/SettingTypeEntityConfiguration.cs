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
    public class SettingTypeEntityConfiguration : IEntityTypeConfiguration<SettingType>
    {
        public void Configure(EntityTypeBuilder<SettingType> builder)
        {
            builder.ToTable("setting_types");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
        }
    }
}
