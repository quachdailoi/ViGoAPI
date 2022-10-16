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
        public int? NextRouteStationId { get; set; } = null;
        public double DistanceFromFirstStationInRoute { get; set; }
        public double DurationFromFirstStationInRoute { get; set; }
        public Routes.RouteStationStatus Status { get; set; } = Routes.RouteStationStatus.Active;

        public Route Route { get; set; }
        public Station Station { get; set; }
        public RouteStation? NextRouteStation { get; set; } = null;
        //public RouteStation? PrevRouteStation { get; set; } = null;

        /* Omitted */
        public virtual List<Booking> StartRouteStationBookings { get; set; } = new();
        public virtual List<Booking> EndRouteStationBookings { get; set; } = new();
    }
}
