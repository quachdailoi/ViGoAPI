using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class RouteDTO : BaseDTO
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        //public Location StartPoint { get; set; } = new();
        //public Location EndPoint { get; set; } = new();
        public List<Step> Steps { get; set; } = new();
        public double Distance { get; set; }
        public double Duration { get; set; }
        public Bound Bound { get; set; } = new();
        public StatusTypes.Route Status { get; set; } = StatusTypes.Route.Active;
    }
}
