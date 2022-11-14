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
    public class WalletEntityConfiguration : BaseEntityConfiguration<Wallet>
    {
        public override void Configure(EntityTypeBuilder<Wallet> builder)
        {
            base.Configure(builder);

            builder.ToTable("wallets");

            builder.Property(e => e.Balance)
                .HasColumnName("balance");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.Property(e => e.Status)
                .HasColumnName("status");

            builder.Property(e => e.Type)
                .HasColumnName("type");

            builder.HasOne(e => e.User)
                .WithOne(u => u.Wallet)
                .HasForeignKey<Wallet>(e => e.UserId);
        }
    }
}
