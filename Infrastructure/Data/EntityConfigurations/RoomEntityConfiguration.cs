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
    public class RoomEntityConfiguration : BaseEntityConfiguration<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);

            builder.ToTable("rooms");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasDefaultValue(new Guid())
                .HasColumnName("code");

            builder.Property(e => e.Status)
                .HasConversion<int>()
                .HasDefaultValue(StatusTypes.Room.Active)
                .IsRequired()
                .HasColumnName("status");

            builder.Property(e => e.Type)
                .HasConversion<int>()
                .IsRequired()
                .HasColumnName("type");

            builder.HasIndex(e => e.Code).IsUnique();
        }
    }
}
