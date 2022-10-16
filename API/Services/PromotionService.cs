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
    public class PromotionService : BaseService, IPromotionService
    {
        public PromotionService(IAppServices appServices) : base(appServices)
        {
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

        private async Task<List<PromotionViewModel>> GetAvailablePromotion(int userId, double? totalPrice = null, int? totalTickets = null, Payments.PaymentMethods? paymentMethods = null, VehicleTypes.Type? vehicleTypes = null)
        {
            var userPromotions = UnitOfWork.PromotionUsers.GetUsedPromotion(userId);

            var validPromotions = ValidatePromotionCondition(UnitOfWork.Promotions.GetAll());

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
                           FilePath = AppServices.File.GetPresignedUrl(validPromotion.File),
                           Available = CheckBookingAvailable(validPromotion.PromotionCondition, totalPrice, totalTickets, paymentMethods, vehicleTypes),
                           ValidFrom = validPromotion.PromotionCondition.ValidFrom,
                           ValidUntil = validPromotion.PromotionCondition.ValidUntil,
                       }).ToListAsync();

            return availablePromotions;
        }

        private static bool CheckBookingAvailable(PromotionCondition condition, double? totalPrice, int? totalTickets, Payments.PaymentMethods? paymentMethods, VehicleTypes.Type? vehicleTypes)
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
                await UnitOfWork.Promotions.List().Where(CheckPromotionValidFrom).Where(CheckPromotionValidUntil)
                    .OrderByDescending(x => x.CreatedAt)
                    .MapTo<PromotionViewModel>(Mapper)
                    .ToListAsync();

            if (!bannerPromotions.Any()) return emptyResponse;

            return successResponse.SetData(bannerPromotions);
        }

        public async Task<Promotion?> GetPromotionByCode(string code, int userId, double totalPrice, int totalTickets, Payments.PaymentMethods paymentMethods)
        {
            var userPromotions = UnitOfWork.PromotionUsers.GetUsedPromotion(userId);

            var validPromotions =
                ValidatePromotionCondition(UnitOfWork.Promotions.GetAll().Where(promotion => promotion.Code == code));

            var promotions = UnitOfWork.Promotions.List(promotion => promotion.Code == code);

            var result =
               await (from validPromotion in validPromotions
                      join userPromotion in userPromotions
                      on validPromotion.Id equals userPromotion.PromotionId
                      into joined
                      from up in joined.DefaultIfEmpty()
                      where up == null || (validPromotion.PromotionCondition.UsagePerUser > up.Used && (up.ExpiredTime == null || up.ExpiredTime > DateTimeOffset.Now))
                     select new {Promotion = validPromotion, IsBookingAvailable = CheckBookingAvailable(validPromotion.PromotionCondition, totalPrice, totalTickets,paymentMethods,null)}
                     ).FirstOrDefaultAsync();


            return result != null && result.IsBookingAvailable ? result.Promotion : null;
        }
    }
}
