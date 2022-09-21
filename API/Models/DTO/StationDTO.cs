using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class StationDTO : BaseDTO
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public StatusTypes.Station Status { get; set; } = StatusTypes.Station.Active;
    }
}
