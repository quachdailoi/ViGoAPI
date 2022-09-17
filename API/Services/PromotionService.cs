using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace API.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public PromotionService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<Response> GetAvailablePromotion(int userId, Response successResponse, Response emptyResponse)
        {
            var availablePromotions = await GetAvailablePromotion(userId);

            if (!availablePromotions.Any()) return emptyResponse;

            return successResponse.SetData(availablePromotions);
        }

        public async Task<Response> GetAvailablePromotion(int userId, BookingPromotionRequest request, Response successResponse, Response emptyResponse)
        {
            var availablePromotions = await GetAvailablePromotion(userId , request.TotalPrice, request.TotalTickets, request.PaymentMethods, request.VehicleTypes);

            if (!availablePromotions.Any()) return emptyResponse;

            return successResponse.SetData(availablePromotions);
        }

        private async Task<List<PromotionViewModel>> GetAvailablePromotion(int userId, double? totalPrice = null, int? totalTickets = null, PaymentMethods? paymentMethods = null, VehicleTypes? vehicleTypes = null)
        {
            var userPromotions = _unitOfWork.PromotionUsers.GetUsedPromotion(userId);

            var validPromotions = ValidatePromotionCondition(_unitOfWork.Promotions.GetAll());

            var availablePromotions = 
                await (from validPromotion in validPromotions
                       join userPromotion in userPromotions
                       on validPromotion.Id equals userPromotion.PromotionId
                       into joined
                       from up in joined.DefaultIfEmpty()
                       where up == null || (validPromotion.PromotionCondition.UsagePerUser > up.Used && (up.ExpiredTime == null || up.ExpiredTime > DateTimeOffset.Now))
                       select new PromotionViewModel
                       {
                           Code = validPromotion.Code,
                           Details = validPromotion.Details,
                           Name = validPromotion.Name,
                           Quantity = (validPromotion.PromotionCondition.UsagePerUser - (up != null ? up.Used : 0)) ?? 0,
                           FilePath = _fileService.GetPresignedUrl(validPromotion.File),
                           Available = CheckBookingAvailable(validPromotion.PromotionCondition, totalPrice, totalTickets, paymentMethods, vehicleTypes),
                           ValidFrom = validPromotion.PromotionCondition.ValidFrom,
                           ValidUntil = validPromotion.PromotionCondition.ValidUntil,
                       }).ToListAsync();

            return availablePromotions;
        }

        private static bool CheckBookingAvailable(PromotionCondition condition, double? totalPrice, int? totalTickets, PaymentMethods? paymentMethods, VehicleTypes? vehicleTypes)
        {
            if (totalPrice != null && condition.MinTotalPrice != null && totalPrice < condition.MinTotalPrice) return false;

            if (totalTickets != null && condition.MinTickets != null && totalTickets < condition.MinTickets) return false;

            if (paymentMethods != null && condition.PaymentMethods != null && paymentMethods !=  condition.PaymentMethods) return false;

            if (vehicleTypes != null && condition.VehicleTypes != null && vehicleTypes != condition.VehicleTypes) return false;

            return true;
        }

        private IQueryable<Promotion> ValidatePromotionCondition(IQueryable<Promotion> promotion)
        {
            var availablePromotion =
                promotion.Where(CheckPromotionTotalUsageExp);

            availablePromotion =
                availablePromotion.Where(CheckPromotionValidFrom);

            availablePromotion =
                availablePromotion.Where(CheckPromotionValidUntil);

            return availablePromotion;
        }

        private Expression<Func<Promotion, bool>> CheckPromotionTotalUsageExp =>
            x => x.PromotionCondition.TotalUsage == null || (x.PromotionCondition.TotalUsage > 0);

        private Expression<Func<Promotion, bool>> CheckPromotionValidFrom =>
            x => x.PromotionCondition.ValidFrom == null || (x.PromotionCondition.ValidFrom < DateTimeOffset.Now);

        private Expression<Func<Promotion, bool>> CheckPromotionValidUntil =>
            x => x.PromotionCondition.ValidUntil == null || (x.PromotionCondition.ValidUntil > DateTimeOffset.Now);

        public async Task<Response> GetBannerPromotion(Response successResponse, Response emptyResponse)
        {
            var bannerPromotions = 
                await _unitOfWork.Promotions.List().Where(CheckPromotionValidFrom).Where(CheckPromotionValidUntil)
                    .OrderByDescending(x => x.CreatedAt)
                    .MapTo<PromotionViewModel>(_mapper)
                    .ToListAsync();

            if (!bannerPromotions.Any()) return emptyResponse;

            return successResponse.SetData(bannerPromotions);
        }
    }
}
