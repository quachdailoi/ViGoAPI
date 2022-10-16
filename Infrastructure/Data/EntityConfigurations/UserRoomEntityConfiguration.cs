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
    public class UserRoomEntityConfiguration : BaseEntityConfiguration<UserRoom>
    {
        public override void Configure(EntityTypeBuilder<UserRoom> builder)
        {
            base.Configure(builder);

            builder.ToTable("user_rooms");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.RoomId)
                .IsRequired()
                .HasColumnName("room_id");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("status")
                .HasDefaultValue(Rooms.UserRoomStatus.Active);

            builder.Property(e => e.LastSeenTime)
                .HasColumnName("last_seen_time")
                .HasDefaultValue(DateTimeOffset.Now);

            builder.HasOne(e => e.User)
                .WithMany(u => u.UserRooms)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Room)
                .WithMany(r => r.UserRooms)
                .HasForeignKey(e => e.RoomId);
                   
        }
    }
}
