using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehicleType
    {
        public VehicleTypes.SpecificType Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;
        public int Slot { get; set; }
        public VehicleTypes.Type Type { get; set; } = VehicleTypes.Type.ViRide;
        public VehicleTypes.Status Status { get; set; } = VehicleTypes.Status.Active;

        public Fare Fare { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new();
        public List<Booking> Bookings { get; set; } = new();
    }
}
