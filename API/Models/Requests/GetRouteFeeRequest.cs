namespace API.Models.Requests
{
    public class GetRouteFeeRequest
    {
        public Guid StationCode { get; set; }
        public double EndPointLongitude { get; set; }
        public double EndPointLatitude { get; set; }
    }
}
