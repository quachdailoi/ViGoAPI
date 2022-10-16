using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class VehicleTypes
    {
        public enum Type
        {
            [Description("ViRide")]
            ViRide,
            [Description("ViCar")]
            ViCar
        }
        
        public enum Status
        {
            Inactive,
            Active,
        }
    }
}
