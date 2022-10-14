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
    public class BannerEntityConfiguration : BaseEntityConfiguration<Banner>
    {
        public override void Configure(EntityTypeBuilder<Banner> builder)
        {
            base.Configure(builder);

            builder.Navigation(b => b.File).AutoInclude();

            builder.ToTable("banners");

            builder.Property(e => e.FileId)
                .IsRequired()
                .HasColumnName("file_id");

            builder.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content");

            builder.Property(e => e.Priority)
                .HasColumnName("priority");

            builder.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnName("active");
        }
    }
}
