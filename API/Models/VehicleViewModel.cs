﻿namespace API.Models
{
    public class VehicleViewModel
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
        public string LicensePlate { get; set; }
        public VehicleTypeViewModel Type { get; set; }
    }
}