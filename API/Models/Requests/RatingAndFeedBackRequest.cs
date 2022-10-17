namespace API.Models.Requests
{
    public class RatingAndFeedbackRequest
    {
        public string BookingDetailCode { get; set; }
        public double? Rating { get; set; }
        public string? FeedBack { get; set; }
    }
}
