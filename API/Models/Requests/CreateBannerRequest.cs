namespace API.Models.Requests
{
    public class CreateBannerRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Priority { get; set; } = null;
        public IFormFile File { get; set; }
        public List<IFormFile> Files { get; set; } = new();
    }
}
