using API.Models.Requests;
using API.Models.Response;

namespace API.Services.Constract
{
    public interface IBannerService
    {
        Task<Response> GetHomeBanners(Response succeess);
        Task<Response> GetAllBanners(string title, Response succeess);
        Task<Response> Create(CreateBannerRequest request, Response successResponse, Response failResponse);
        Task<Response> Update(UpdateBannerRequest request, Response successResponse, Response notExistResponse, Response failResponse);
        Task<Response> UpdatePriority(Dictionary<int, int> pairs, Response successResponse, Response failResponse);
    }
}
