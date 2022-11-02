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
    public class WalletTransactionEntityConfiguration : BaseEntityConfiguration<WalletTransaction>
    {
        public override void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            base.Configure(builder);

            builder.ToTable("wallet_transactions");

            builder.Property(e => e.Code)
                .HasColumnName("code");

            builder.Property(e => e.Amount)
                .HasColumnName("amount");

            builder.Property(e => e.Type)
                .HasColumnName("type");

            builder.Property(e => e.TxnId)
                .HasColumnName("txn_id");

            builder.Property(e => e.BookingId)
                .HasColumnName("booking_id");

            builder.Property(e => e.WalletId)
                .HasColumnName("wallet_id");

            builder.HasOne(e => e.Wallet)
                .WithMany(w => w.WalletTransactions)
                .HasForeignKey(e => e.WalletId);

            builder.HasOne(e => e.Booking)
                .WithMany(b => b.WalletTransactions)
                .HasForeignKey(e => e.BookingId);

            builder.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}
