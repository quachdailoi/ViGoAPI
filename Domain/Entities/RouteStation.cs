using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RouteStation
    {
        public int RouteId { get; set; }
        public int StationId { get; set; }
        public int Index { get; set; }
        public StatusTypes.RouteStation Status { get; set; } = StatusTypes.RouteStation.Active;
    }
}
