using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class VehicleTypes
    {
        public enum Type
        {
            ViRide,
            ViCar
        }
        
        public enum Status
        {
            Active,
            Inactive
        }
    }

    public static class VehicleTypesExtensions
    {
        public static string GetString(this VehicleTypes.Type type)
        {
            return type switch
            {
                VehicleTypes.Type.ViRide => "ViRide",
                VehicleTypes.Type.ViCar => "ViCar",
                _ => String.Empty,
            };
        }
    }
}
