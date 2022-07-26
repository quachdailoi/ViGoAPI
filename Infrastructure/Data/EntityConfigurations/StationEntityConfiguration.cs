﻿using Domain.Entities;
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
    public class StationEntityConfiguration : BaseEntityConfiguration<Station>
    {
        public override void Configure(EntityTypeBuilder<Station> builder)
        {
            base.Configure(builder);

            builder.ToTable("stations");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            builder.Property(e => e.Latitude)
                .IsRequired()
                .HasColumnName("latitude");

            builder.Property(e => e.Longitude)
                .IsRequired()
                .HasColumnName("longitude");

            builder.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");

            builder.Property(e => e.Address)
                .HasMaxLength(256)
                .HasColumnName("address");

            builder.Property(e => e.Status)
                .HasColumnName("status");

            builder.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}
