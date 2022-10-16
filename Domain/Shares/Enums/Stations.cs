using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Stations
    {
        public enum Status
        {
            Inactive,
            Active
        }

        public enum StopStationTypes
        {
            Pickup,
            Dropoff
        }
    }
}
