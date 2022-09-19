using API.Extensions;
using API.Models;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BannerService : IBannerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BannerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> GetHomeBanners(Response succeess)
        {
            var banners = await _unitOfWork.Banners.GetAll()
                .Where(x => x.Active == true && x.Priority != null)
                .OrderBy(x => x.Priority)
                .MapTo<BannerViewModel>(_mapper)
                .ToListAsync();

            return succeess.SetData(banners);
        }
    }
}
