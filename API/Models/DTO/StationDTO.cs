using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class StationDTO : BaseDTO
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public StatusTypes.Station Status { get; set; } = StatusTypes.Station.Active;
    }
}
