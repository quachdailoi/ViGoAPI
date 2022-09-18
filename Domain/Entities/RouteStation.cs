using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RouteStation : BaseEntity
    {
        public int RouteId { get; set; }
        public int StationId { get; set; }
        public int Index { get; set; }
        public double DistanceFromFirstStationInRoute { get; set; }
        public StatusTypes.RouteStation Status { get; set; } = StatusTypes.RouteStation.Active;

        public Route Route { get; set; }
        public Station Station { get; set; }
    }
}
