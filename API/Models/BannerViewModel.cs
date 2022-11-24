namespace API.Models
{
    public class BannerViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Priority { get; set; }
        public string? FilePath { get; set; }
    }

    public class AdminBannerViewModel : BannerViewModel
    {
        public int Id { get; set; }
    }
}
