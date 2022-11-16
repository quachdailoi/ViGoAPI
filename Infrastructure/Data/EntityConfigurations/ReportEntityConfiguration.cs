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
    public class ReportEntityConfiguration : BaseEntityConfiguration<Report>
    {
        public override void Configure(EntityTypeBuilder<Report> builder)
        {
            base.Configure(builder);

            builder.ToTable("reports");

            builder.Property(e => e.Code)
                .HasColumnName("code");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.Title)
                .HasColumnName("title");

            builder.Property(e => e.Content)
                .HasColumnName("content");

            builder.Property(e => e.Type)
                .HasColumnName("type");

            builder.Property(e => e.Data)
                .HasColumnType("jsonb")
                .HasColumnName("data");

            builder.Property(e => e.Status)
                .HasColumnName("status");

            builder.HasOne(e => e.User)
                .WithMany(u => u.Reports)
                .HasForeignKey(e => e.UserId);

            builder.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}
