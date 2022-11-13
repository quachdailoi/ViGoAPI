using Domain.Entities;

namespace API.Models.DTO
{
    public class StepInTripDTO
    {
        public RouteStation RouteStation { get; set; }
        public int Count { get; set; }
    }
}
