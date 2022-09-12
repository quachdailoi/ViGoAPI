using Domain.Entities;
using Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class FileEntityConfiguration : BaseEntityConfiguration<AppFile>
    {
        public override void Configure(EntityTypeBuilder<AppFile> builder)
        {
            base.Configure(builder);

            builder.ToTable("files");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            builder.Property(e => e.Path)
                .IsRequired()
                .HasColumnName("path");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type")
                .HasConversion<int>();

            builder.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("status");

            // config foreign key
            builder.HasOne(e => e.User)
                .WithOne(e => e.File)
                .HasForeignKey<User>(e => e.FileId);

            builder.HasOne(e => e.Promotion)
                .WithOne(e => e.File)
                .HasForeignKey<Promotion>(e => e.FileId);
        }
    }
}
