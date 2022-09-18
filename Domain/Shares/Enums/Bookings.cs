using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Bookings
    {
        public enum Types{
            Monthly,
            Weekly
        }
        
        public enum Options
        {
            None,
            IgnoreSunDay,
            IgnoreSaturdayAndSunDay
        }
    }
}
