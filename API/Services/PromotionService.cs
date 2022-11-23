using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Settings;
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
                    .MapTo<PromotionViewModel>(Mapper, AppServices)
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

        public async Task<Response> Create(CreatePromotionRequest request, Response successResponse, Response duplicateResponse, Response errorResponse)
        {
            var promotion = Mapper.Map<Promotion>(request);

            if (!string.IsNullOrWhiteSpace(request.Code))
            {
                if (UnitOfWork.Promotions.List(x => x.Code == request.Code).Any())
                    return duplicateResponse;

                promotion.Code = request.Code;
            }
            else
            {
                //generate code
                do
                {
                    promotion.Code = Guid.NewGuid().ToString().Split("-").Last().Substring(0, 10).ToUpper();
                } while (UnitOfWork.Promotions.List(x => x.Code == promotion.Code).Any());
            }

            if (request.File != null)
            {
                var file = await AppServices.File.UploadFileAsync($"{Configuration.Get<string>(AwsSettings.PromotionFolder)}{Guid.NewGuid()}", request.File, FileTypes.PromotionImage);
                if (file == null) return errorResponse;
                promotion.FileId = file.Id;
            }

            var promotionCondition = Mapper.Map<PromotionCondition>(request);

            promotion.PromotionCondition = promotionCondition;

            promotion = await UnitOfWork.Promotions.Add(promotion);

            if (promotion == null) return errorResponse;

            var promotionVM = await UnitOfWork.Promotions
                .List(x => x.Id == promotion.Id)
                .MapTo<AdminPromotionViewModel>(Mapper, AppServices)
                .FirstOrDefaultAsync();

            return successResponse.SetData(promotionVM);
        }

        public async Task<Response> Update(int promotionId, UpdatePromotionRequest request, Response successResponse, Response notExistResponse,Response errorResponse)
        {
            var promotion = await UnitOfWork.Promotions
                .List(x => x.Id == promotionId)
                .Include(x => x.PromotionCondition)
                .Include(x => x.File)
                .FirstOrDefaultAsync();

            if (promotion == null) return notExistResponse;

            promotion.Code = request.Code;
            promotion.Name = request.Name;
            promotion.Details = request.Details;
            promotion.DiscountPercentage = request.DiscountPercentage;
            promotion.MaxDecrease = request.MaxDecrease;
            promotion.Type = request.Type;
            promotion.Status = request.Status;

            // update condition
            promotion.PromotionCondition.TotalUsage = request.TotalUsage;
            promotion.PromotionCondition.UsagePerUser = request.UsagePerUser;
            promotion.PromotionCondition.ValidFrom = request.ValidFromParsed();
            promotion.PromotionCondition.ValidUntil = request.ValidFromParsed();
            promotion.PromotionCondition.MinTickets = request.MinTickets;
            promotion.PromotionCondition.MinTotalPrice = request.MinTotalPrice;
            promotion.PromotionCondition.PaymentMethods = request.PaymentMethods;
            promotion.PromotionCondition.VehicleTypes = request.VehicleTypes;

            // update user promotion

            // file
            if (request.File != null)
            {
                if (promotion.File != null)
                {
                    if (!await AppServices.File.UpdateS3File(promotion.File.Path, request.File)) return errorResponse;
                }
                else
                {
                    var file = await AppServices.File.UploadFileAsync($"{Configuration.Get<string>(AwsSettings.PromotionFolder)}{Guid.NewGuid()}", request.File, FileTypes.PromotionImage);
                    if (file == null) return errorResponse;
                    promotion.FileId = file.Id;
                }                    
            }

            //promotion.PromotionCondition = Mapper.Map<PromotionCondition>(request);

            if (!await UnitOfWork.Promotions.Update(promotion)) return errorResponse;

            return successResponse;
        }

        public Task<List<AdminPromotionViewModel>> Get()
        => UnitOfWork.Promotions
            .List(x => x.Status == Promotions.Status.Available)
            .MapTo<AdminPromotionViewModel>(Mapper, AppServices)
            .ToListAsync();
    }
}
