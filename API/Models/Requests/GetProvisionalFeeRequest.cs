using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class GetProvisionalFeeRequest
    {
        public double Distance { get; set; }
        public TimeOnly Time { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public int TotalDays { get; set; }
    }
}
