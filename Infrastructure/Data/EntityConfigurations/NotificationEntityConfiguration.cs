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
    public class NotificationEntityConfiguration : BaseEntityConfiguration<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);

            builder.ToTable("notifications");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            builder.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type");

            builder.Property(e => e.Data)
                .HasColumnType("jsonb")
                .HasColumnName("data");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("status");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.Property(e => e.EventId)
                .IsRequired()
                .HasColumnName("event_id");

            builder.HasIndex(e => e.Code)
                .IsUnique();

            builder.HasOne(e => e.Event)
                .WithMany(ev => ev.Notifications)
                .HasForeignKey(e => e.EventId);

            builder.HasOne(e => e.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(e => e.UserId);
        }
    }
}
