using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Fare : BaseEntity
    {
        public double BasePrice { get; set; }
        public double PricePerKm { get; set; }
        public int BaseDistance { get; set; }
        public int VehicleTypeId { get; set; }
       
        public VehicleType VehicleType { get; set; }
        public List<FareTimeline> FareTimelines { get; set; }
    }
}
