using Domain.Entities;
using Domain.Shares.Enums;
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
    public class MessageEntityConfiguration : BaseEntityConfiguration<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            base.Configure(builder);

            builder.ToTable("messages");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.RoomId)
                .IsRequired()
                .HasColumnName("room_id");

            builder.Property(e => e.Status)
                .HasConversion<int>()
                .HasDefaultValue(StatusTypes.Message.Active)
                .HasColumnName("status");

            builder.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content");

            builder.HasOne(e => e.Room)
                .WithMany(r => r.Messages)
                .HasForeignKey(e => e.RoomId);

            builder.HasOne(e => e.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(e => e.UserId);
        }
    }
}
