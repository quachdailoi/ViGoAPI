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
    public class UserLicenseEntityConfiguration : BaseEntityConfiguration<UserLicense>
    {
        public override void Configure(EntityTypeBuilder<UserLicense> builder)
        {
            base.Configure(builder);

            builder.ToTable("user_licenses");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            builder.Property(e => e.FrontSideFileId)
                .HasColumnName("front_side_file_id");

            builder.Property(e => e.BackSideFileId)
                .HasColumnName("back_side_file_id");

            builder.Property(e => e.LicenseTypeId)
                .HasConversion<int>()
                .HasColumnName("license_type_id");

            builder.HasOne(e => e.User)
                .WithMany(p => p.UserLicenses)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.LicenseType)
                .WithMany(p => p.UserLicenses)
                .HasForeignKey(e => e.LicenseTypeId);

            builder.HasIndex(e => e.Code).IsUnique();

            builder.HasOne(x => x.FrontSideFile)
                .WithMany(s => s.FrontSideUserLicenses)
                .HasForeignKey(e => e.FrontSideFileId);

            builder.HasOne(x => x.BackSideFile)
                .WithMany(s => s.BackSideUserLicenses)
                .HasForeignKey(e => e.BackSideFileId);
        }
    }
}
