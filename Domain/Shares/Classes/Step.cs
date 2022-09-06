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
        public Location StartPoint { get; set; }
        public Location EndPoint { get; set; }
        public string Maneuver { get; set; }
        public Bound Bound { get; set; }
    }
}
