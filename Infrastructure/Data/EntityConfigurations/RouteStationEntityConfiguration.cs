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
    public class RouteStationEntityConfiguration : BaseEntityConfiguration<RouteStation>
    {
        public override void Configure(EntityTypeBuilder<RouteStation> builder)
        {
            base.Configure(builder);

            builder.ToTable("route_stations");

            builder.Property(e => e.RouteId)
                .HasColumnName("route_id");

            builder.Property(e => e.StationId)
                .HasColumnName("station_id");

            builder.Property(e => e.Index)
                .HasColumnName("index");

            builder.Property(e => e.DistanceFromFirstStationInRoute)
                .HasColumnName("distance_from_first_station_in_route");

            builder.Property(e => e.DurationFromFirstStationInRoute)
                .HasColumnName("duration_from_first_station_in_route");

            builder.Property(e => e.Status)
                .HasColumnName("status");

            builder.HasOne(e => e.Route)
                .WithMany(r => r.RouteStations)
                .HasForeignKey(e => e.RouteId);

            builder.HasOne(e => e.Station)
                .WithMany(s => s.RouteStations)
                .HasForeignKey(e => e.StationId);

            //builder.HasIndex(e => new { e.RouteId, e.StationId })
            //    .IsUnique();
        }
    }
}
