using Domain.Entities.Base;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Route : BaseEntity
    {
        public Location StartPoint { get; set; } = new();
        public Location EndPoint { get; set; } = new();
        public List<Step> Steps { get; set; } = new();
        public double Distance { get; set; }
        public double Duration { get; set; }
        public Bound Bound { get; set; } = new();
        public StatusTypes.Route Status { get; set; } = StatusTypes.Route.Active;

        public List<RouteStation> RouteStations { get; set; } = new();
    }
}
