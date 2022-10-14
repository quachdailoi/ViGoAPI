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
    public class AffiliatePartyTypeEntityConfiguration : IEntityTypeConfiguration<AffiliatePartyType>
    {
        public void Configure(EntityTypeBuilder<AffiliatePartyType> builder)
        {
            builder.ToTable("affiliate_party_types");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status");

            builder.HasIndex(e => e.Id)
                .IsUnique();

            builder.HasIndex(e => e.Code)
                .IsUnique();

            builder.HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}
