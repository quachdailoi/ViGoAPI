using API.Extensions;
using Domain.Entities;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class VehicleTypeViewModel
    {
        public int Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;
        public int Slot { get; set; }
        [JsonIgnore]
        public VehicleTypes.Type Type { get; set; } = VehicleTypes.Type.ViRide;
        public string TypeName { get => Type.DisplayName(); }
        [JsonIgnore]
        public VehicleTypes.Status Status { get; set; } = VehicleTypes.Status.Active;
        public string StatusName { get => Status.DisplayName(); }
    }

    public class VehicleTypeWithFareViewModel : VehicleTypeViewModel
    {
        public FareViewModel Fare { get; set; }
    }

    public class FareViewModel
    {
        public double BasePrice { get; set; }
        public double PricePerKm { get; set; }
        public int BaseDistance { get; set; }
        [JsonIgnore]
        public int VehicleTypeId { get; set; }

        public List<FareTimeLineViewModel> FareTimelines { get; set; } = new();
    }

    public class FareTimeLineViewModel
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        [JsonIgnore]
        public int FareId { get; set; }
        public double ExtraFeePerKm { get; set; }
        public double CeilingExtraPrice { get; set; }
    }
}
