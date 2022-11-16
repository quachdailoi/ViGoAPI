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

        public enum SpecificType
        {
            [Description("ViRide")]
            ViRide = 1,
            [Description("ViCar-4")]
            ViCar4 = 2,
            [Description("ViCar-7")]
            ViCar7 = 3
        }
    }
}
