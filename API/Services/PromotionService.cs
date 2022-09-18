using API.Extensions;
using API.Models;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public PromotionService(
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<Response> GetAvailablePromotion(int userId, Response successResponse, Response emptyResponse)
        {
            var availablePromotions = await GetAvailablePromotion(userId);

            if (!availablePromotions.Any()) return emptyResponse;

            return successResponse.SetData(availablePromotions);
        }

        public async Task<Response> GetAvailablePromotion(int userId, double? totalPrice, int? totalTickets, Response successResponse, Response emptyResponse)
        {
            var availablePromotions = await GetAvailablePromotion(userId ,totalPrice, totalTickets);

            if (!availablePromotions.Any()) return emptyResponse;

            return successResponse.SetData(availablePromotions);
        }

        private async Task<List<PromotionViewModel>> GetAvailablePromotion(int userId, double? totalPrice = null, int? totalTickets = null)
        {
            var userPromotions = _unitOfWork.PromotionUsers.GetUsedPromotion(userId);

            var promotionConditions = 
                ValidateCondition(_unitOfWork.Promotions.GetAll().Select(x => x.PromotionCondition));

            var availablePromotions =
                await (from condition in promotionConditions
                       join userPromotion in userPromotions
                       on condition.PromotionId equals userPromotion.PromotionId
                       into joined
                       from up in joined.DefaultIfEmpty()
                       where up == null || (condition.UsagePerUser > up.Used && (up.ExpiredTime == null || up.ExpiredTime > DateTimeOffset.Now))
                       
                       select new PromotionViewModel
                       {
                           Code = condition.Promotion.Code,
                           Details = condition.Promotion.Details,
                           Name = condition.Promotion.Name,
                           Quantity = (condition.UsagePerUser - (up != null ? up.Used : 0)) ?? 0,
                           FilePath = _fileService.GetPresignedUrl(condition.Promotion.File),
                           Available = CheckBookingAvailable(condition, totalPrice, totalTickets)
                       }).ToListAsync();

            return availablePromotions;
        }

        private static bool CheckBookingAvailable(PromotionCondition condition, double? totalPrice, int? totalTickets)
        {
            if (totalPrice != null && totalPrice < condition.MinTotalPrice) return false;

            if (totalTickets != null && totalTickets < condition.MinTickets) return false;

            return true;
        }

        private IQueryable<PromotionCondition> ValidateCondition(IQueryable<PromotionCondition> conditions)
        {
            var rightCondition = 
                conditions.Where(x => x.TotalUsage == null || 
                    (x.TotalUsage > 0));

            rightCondition = 
                rightCondition.Where(x => x.ValidFrom == null || 
                    (x.ValidFrom < DateTimeOffset.Now));

            rightCondition =
                rightCondition.Where(x => x.ValidUntil == null ||
                    (x.ValidUntil > DateTimeOffset.Now));

            return rightCondition;
        }

        public async Task<Promotion?> GetPromotionByCode(string code, int userId, double totalPrice, int totalTickets)
        {
            var userPromotions = _unitOfWork.PromotionUsers.GetUsedPromotion(userId);

            var promotionConditions =
                ValidateCondition(_unitOfWork.Promotions.GetAll().Select(x => x.PromotionCondition));

            var promotions = _unitOfWork.Promotions.List(promotion => promotion.Code == code);

            var result =
               await (from condition in promotionConditions
                     join userPromotion in userPromotions
                        on condition.PromotionId equals userPromotion.PromotionId
                        into joined
                     from up in joined.DefaultIfEmpty()
                     where up == null || (condition.UsagePerUser > up.Used && (up.ExpiredTime == null || up.ExpiredTime > DateTimeOffset.Now))
                     join _promotion in promotions
                        on condition.PromotionId equals _promotion.Id
                        into _joined
                     from _up in _joined.DefaultIfEmpty()
                     select new {Promotion = _up, IsBookingAvailable = CheckBookingAvailable(condition, totalPrice, totalTickets)}
                     ).FirstOrDefaultAsync();


            return result != null && result.IsBookingAvailable ? result.Promotion : null;
        }
    }
}
