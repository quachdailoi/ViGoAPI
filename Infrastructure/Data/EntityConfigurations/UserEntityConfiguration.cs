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
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Navigation(u => u.File).AutoInclude();

            builder.Navigation(u => u.Accounts).AutoInclude();

            builder.ToTable("users");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("gender");            

            builder.Property(e => e.DateOfBirth)
                .HasColumnName("date_of_birth");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("status");

            builder.Property(e => e.FileId)
                .HasColumnName("file_id");

            builder.Property(e => e.FCMToken)
                .IsRequired(false)
                .HasColumnName("fcm_token");

            builder.Property(e => e.Rating)
                .IsRequired(false)
                .HasColumnName("rating");

            builder.Property(e => e.CancelledTripRate)
                .HasColumnName("cancelled_trip_rate");

            builder.Property(e => e.SuddenlyCancelledTrips)
                .HasColumnName("suddenly_cancelled_trips");

            builder.HasIndex(e => e.Code).IsUnique();
        }
    }
}
