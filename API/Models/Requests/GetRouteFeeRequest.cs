using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class GetRouteFeeRequest
    {
        //public Guid StationCode { get; set; }
        //public double EndPointLongitude { get; set; }
        //public double EndPointLatitude { get; set; }

        public Guid StartStationCode { get; set; }
        public Guid EndStationCode { get; set; }
        public VehicleTypes VehicleType { get; set; } = VehicleTypes.ViRide;
    }
}
