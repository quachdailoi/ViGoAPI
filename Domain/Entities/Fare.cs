using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Fare : BaseEntity
    {
        public double BasePrice { get; set; }
        public double PricePerKm { get; set; }
        public int BaseDistance { get; set; }
        [JsonIgnore]
        public VehicleTypes.SpecificType VehicleTypeId { get; set; }

        [JsonIgnore]
        public VehicleType VehicleType { get; set; }
        public List<FareTimeline> FareTimelines { get; set; } = new();
    }
}
