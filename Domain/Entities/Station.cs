using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Station : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public StatusTypes.Station Status { get; set; } = StatusTypes.Station.Active;

        public List<RouteStation> RouteStations { get; set; } = new();
    }
}
