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
        public Guid Code { get; set; } = Guid.NewGuid();
        public List<Step> Steps { get; set; } = new();
        public double Distance { get; set; }
        public double Duration { get; set; }
        public Bound Bound { get; set; } = new();
        public Routes.Status Status { get; set; } = Routes.Status.Active;

        public List<RouteStation> RouteStations { get; set; } = new();
        //public List<Booking> Bookings { get; set; } = new();
        public List<RouteRoutine> RouteRoutines { get; set; } = new();
    }
}
