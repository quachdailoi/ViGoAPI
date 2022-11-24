using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Settings;
using API.Services.Constract;
using API.Utilities;
using AutoMapper;
using Domain.Entities;
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
                .MapTo<BannerViewModel>(Mapper, AppServices)
                .ToListAsync();

            return succeess.SetData(banners);
        }

        public async Task<Response> GetAllBanners(string title, Response succeess)
        {
            title = title.Trim().ToLower();
            var banners = await UnitOfWork.Banners.GetAll()
                .Where(x => x.Title.Trim().ToLower().Contains(title))
                .MapTo<BannerViewModel>(Mapper, AppServices)
                .ToListAsync();

            return succeess.SetData(banners);
        }

        public async Task<Response> Create(CreateBannerRequest request, Response successResponse, Response failResponse)
        {
            var banner = new Banner
            {
                Content = request.Content,
                Title = request.Title,
                Priority = request.Priority
            };

            var file = await AppServices.File.UploadFileAsync($"{Configuration.Get<string>(AwsSettings.BannerFolder)}{Guid.NewGuid}", request.File, Domain.Shares.Enums.FileTypes.BannerImage);

            if (file == null)
                return failResponse;

            banner.FileId = file.Id;

            banner = await UnitOfWork.Banners.Add(banner);

            if (banner == null)
                return failResponse;

            var bannerVM = await UnitOfWork.Banners
                .List(x => x.Id == banner.Id)
                .MapTo<BannerViewModel>(Mapper, AppServices)
                .FirstOrDefaultAsync();

            return successResponse.SetData(bannerVM);
        }

        public async Task<Response> Update(UpdateBannerRequest request, Response successResponse, Response notExistResponse,Response failResponse)
        {
            var banner = await UnitOfWork.Banners
                .List(x => x.Id == request.Id)
                .Include(x => x.File)
                .FirstOrDefaultAsync();

            if (banner == null) return notExistResponse;

            banner.Title = request.Title;
            banner.Content = request.Content;
            banner.Priority = request.Priority;
            banner.Active = request.Active;

            if (request.File != null)
            {
                if (!await AppServices.File.UpdateS3File(banner.File.Path, request.File)) return failResponse;
            }


            if (!await UnitOfWork.Banners.Update(banner))
                return failResponse;

            return successResponse;
        }

        public async Task<Response> UpdatePriority(Dictionary<int,int> pairs, Response successResponse, Response failResponse)
        {
            var banners = await UnitOfWork.Banners
                .List(x => pairs.Keys.Contains(x.Id))
                .ToListAsync();

            foreach(var banner in banners)
            {
                banner.Priority = pairs[banner.Id];
            }

            if (!await UnitOfWork.Banners.UpdateRange(banners.ToArray()))
                return failResponse;

            return successResponse;
        }
    }
}
