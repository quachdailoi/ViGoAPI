using API.Models.Response;

namespace API.Services.Constract
{
    public interface IBannerService
    {
        Task<Response> GetHomeBanners(Response succeess);
    }
}
