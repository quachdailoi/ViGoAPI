﻿using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class StationViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public int UpdatedBy { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = string.Empty;
        public StatusTypes.Station Status { get; set; } = StatusTypes.Station.Active;
    }

    public class StationInRouteViewModel : StationViewModel , IComparable<StationInRouteViewModel>
    {
        //public double DistanceFromFirstStationInRoute { get; set; }
        public int Index { get; set; }

        public int CompareTo(StationInRouteViewModel? other)
        {
            return this.Index - other.Index;
        }
    }
}
