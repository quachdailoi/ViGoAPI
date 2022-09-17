using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Classes
{
    public class Step
    {
        public double Distance { get; set; }
        public double Duration { get; set; }
        public Location StartPoint { get; set; } = new();
        public Location EndPoint { get; set; } = new();
        public string Maneuver { get; set; } = String.Empty;
        public Bound Bound { get; set; } = new();
        public int? StationId { get; set; } = null;
        public Station? Station { get; set; }
    }
}
