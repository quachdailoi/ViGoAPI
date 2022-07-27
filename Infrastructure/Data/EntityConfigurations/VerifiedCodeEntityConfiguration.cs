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
    public class VerifiedCodeEntityConfiguration : BaseEntityConfiguration<VerifiedCode>
    {
        public override void Configure(EntityTypeBuilder<VerifiedCode> builder)
        {
            base.Configure(builder);

            builder.ToTable("verified_codes");

            builder.Property(e => e.ExpiredTime)
                .IsRequired()
                .HasColumnName("expired_time");

            builder.Property(e => e.Registration)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("registration");

            builder.Property(e => e.RegistrationType)
                .IsRequired()
                .HasColumnName("registration_type");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("status");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("code");
        }
    }
}
