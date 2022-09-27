using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;
        public string LicensePlate { get; set; } = String.Empty;
        public int VehicleTypeId { get; set; }
        public int UserId { get; set; }

        public VehicleType VehicleType { get; set; }
        public User User { get; set; }
    }
}
