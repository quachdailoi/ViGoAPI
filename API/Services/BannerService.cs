using API.Extensions;
using API.Models;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BannerService : BaseService, IBannerService
    {

        public BannerService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<Response> GetHomeBanners(Response succeess)
        {
            var banners = await UnitOfWork.Banners.GetAll()
                .Where(x => x.Active == true && x.Priority != null)
                .OrderBy(x => x.Priority)
                .MapTo<BannerViewModel>(Mapper)
                .ToListAsync();

            return succeess.SetData(banners);
        }
    }
}
