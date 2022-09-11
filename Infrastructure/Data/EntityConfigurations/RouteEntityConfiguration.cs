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
    public class RouteEntityConfiguration : BaseEntityConfiguration<Route>
    {
        public override void Configure(EntityTypeBuilder<Route> builder)
        {
            base.Configure(builder);

            builder.ToTable("routes");

            builder.Property(e => e.StartPoint)
                .IsRequired()
                .HasColumnType("jsonb")
                .HasColumnName("start_point");

            builder.Property(e => e.EndPoint)
                .IsRequired()
                .HasColumnType("jsonb")
                .HasColumnName("end_point");

            builder.Property(e => e.Steps)
                .IsRequired()
                .HasColumnType("jsonb[]")
                .HasColumnName("steps");

            builder.Property(e => e.Distance)
                .IsRequired()
                .HasColumnName("distance");

            builder.Property(e => e.Duration)
                .IsRequired()
                .HasColumnName("duration");

            builder.Property(e => e.Bound)
                .HasColumnType("jsonb")
                .HasColumnName("bound");

            builder.Property(e => e.Status)
                .HasColumnName("status");
        }
    }
}
