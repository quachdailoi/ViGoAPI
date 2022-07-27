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

            builder.ToTable("users");

            builder.Property(e => e.Code)
                .HasColumnName("code");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasColumnName("gender");            

            builder.Property(e => e.DateOfBirth)
                .IsRequired()
                .HasColumnName("date_of_birth");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("status");
        }
    }
}
