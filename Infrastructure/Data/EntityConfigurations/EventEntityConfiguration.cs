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
    public class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("events");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasConversion<int>();

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("title");

            builder.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(2000)
                .HasColumnName("content");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("status");
        }
    }
}
