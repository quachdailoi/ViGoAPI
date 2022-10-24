using API.Extensions;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class VehicleTypeViewModel
    {
        [JsonIgnore]
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
}
