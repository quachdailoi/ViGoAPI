namespace API.Models.DTO
{
    public class CoordinatesDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid? StartStationCode { get; set; }
    }
}
