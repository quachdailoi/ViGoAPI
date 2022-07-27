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
    public class RoleEntityConfiguration : BaseEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder.ToTable("roles");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("description");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("name");

            builder.HasIndex(e => e.Description).IsUnique();
        }
    }
}
