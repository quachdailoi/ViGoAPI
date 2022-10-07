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
    public class AffiliateAccountEntityConfiguration : BaseEntityConfiguration<AffiliateAccount>
    {
        public override void Configure(EntityTypeBuilder<AffiliateAccount> builder)
        {
            base.Configure(builder);

            builder.ToTable("affiliate_accounts");

            builder.Property(e => e.Token)
                .HasColumnName("token");

            builder.Property(e => e.ExtraData)
                .HasColumnType("jsonb")
                .HasColumnName("extra_data");

            builder.Property(e => e.Status)
                .HasColumnName("status");

            builder.Property(e => e.Type)
                .HasColumnName("type");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.HasOne(e => e.User)
                .WithMany(u => u.AffiliateAccounts)
                .HasForeignKey(e => e.UserId);

            builder.HasIndex(e => new {e.UserId, e.Type })
                .IsUnique();
        }
    }
}
