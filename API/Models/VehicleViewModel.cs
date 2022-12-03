namespace API.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; }
        public string LicensePlate { get; set; }
        public string Type { get; set; }
        public int VehicleTypeId { get; set; }
        public Guid VehicleTypeCode { get; set; }
    }
}
