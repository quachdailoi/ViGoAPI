namespace API.Models
{
    public class StationViewModel
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
