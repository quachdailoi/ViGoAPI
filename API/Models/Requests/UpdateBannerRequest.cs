namespace API.Models.Requests
{
    public class UpdateBannerRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Priority { get; set; } = null;
        public IFormFile? File { get; set; } = null;
        public bool Active { get; set; } = true;
    }
}
