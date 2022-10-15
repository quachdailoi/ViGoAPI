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

            builder.Property(e => e.WalletId)
                .HasColumnName("wallet_id");

            builder.Property(e => e.AffiliatePartyId)
                .HasColumnName("affiliate_party_type_id");

            builder.HasOne(e => e.Wallet)
                .WithMany(w => w.AffiliateAccounts)
                .HasForeignKey(e => e.WalletId);

            builder.HasOne(e => e.AffiliateParty)
                .WithMany(a => a.AffiliateAccounts)
                .HasForeignKey(e => e.AffiliatePartyId);

            builder.HasIndex(e => new {e.WalletId, e.AffiliatePartyId })
                .IsUnique();
        }
    }
}
