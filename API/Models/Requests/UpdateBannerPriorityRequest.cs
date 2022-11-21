namespace API.Models.Requests
{
    public class UpdateBannerPriorityRequest
    {
        public Dictionary<int, int> Banners { get; set; } = new();
    }
}
