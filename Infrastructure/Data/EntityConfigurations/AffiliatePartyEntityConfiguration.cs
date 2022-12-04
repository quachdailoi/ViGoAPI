using Domain.Entities;
using Domain.Interfaces.Entities;
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
    public class AffiliatePartyEntityConfiguration : BaseEntityConfiguration<AffiliateParty>
    {
        public void Configure(EntityTypeBuilder<AffiliateParty> builder)
        {
            builder.ToTable("affiliate_parties");

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
