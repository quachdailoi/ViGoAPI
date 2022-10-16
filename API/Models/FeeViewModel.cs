using System.Text.Json.Serialization;

namespace API.Models
{
    public class FeeViewModel
    {
        [JsonIgnore]
        public double FeePerTrip { get; set; }
        public double Fee { get; set; }
        public double ExtraFee { get; set; }
        public double DiscountFee { get; set; }
        public double TotalFee { get; set; }
    }
}
