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
    public class AccountEntityConfiguration : BaseEntityConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.ToTable("accounts");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.Registration)
                .HasMaxLength(30)
                .HasColumnName("registration");

            builder.Property(e => e.RegistrationType)
                .IsRequired()
                .HasColumnName("registration_type");

            builder.Property(e => e.Verified)
                .IsRequired()
                .HasColumnName("verified")
                .HasDefaultValue(false);

            builder.Property(e => e.RoleId)
                .HasColumnName("role_id");

            // foreign key
            builder.HasOne(e => e.Role)
                .WithMany(e => e.Accounts)
                .HasForeignKey(e => e.RoleId);

            builder.HasOne(e => e.User)
                .WithMany(e => e.Accounts)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.HasIndex(e => new { e.Registration, e.RoleId })
                .IsUnique();
        }
    }
}
