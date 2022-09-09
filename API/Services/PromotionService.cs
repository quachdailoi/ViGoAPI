using API.Extensions;
using API.Models;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PromotionService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> GetAvailablePromotion(int userId, Response successResponse, Response emptyResponse)
        {
            var userPromotions = 
                _unitOfWork.PromotionUsers.GetUsedPromotion(userId);

            var promotionConditions 
                = ValidateCondition(_unitOfWork.Promotions.GetAll().Select(x => x.PromotionCondition));

            var availablePromotions = from condition in promotionConditions
                           join userPromotion in userPromotions
                           on condition.PromotionId equals userPromotion.PromotionId
                           into joined
                           from up in joined.DefaultIfEmpty()
                           where up == null || (condition.UsagePerUser > up.Used && (up.ExpiredTime == null || up.ExpiredTime > DateTime.UtcNow))
                           select new PromotionViewModel
                           {
                               Code = condition.Promotion.Code,
                               Details = condition.Promotion.Details,
                               Name = condition.Promotion.Name,
                               Quantity = (condition.UsagePerUser - (up != null ? up.Used : 0)) ?? 0
                           };

            if (!availablePromotions.Any()) return emptyResponse;

            return successResponse.SetData(availablePromotions);
        }

        private IQueryable<PromotionCondition> ValidateCondition(IQueryable<PromotionCondition> conditions)
        {
            var rightCondition = 
                conditions.Where(x => x.TotalUsage == null || 
                    (x.TotalUsage > 0));

            rightCondition = 
                rightCondition.Where(x => x.ValidFrom == null || 
                    (x.ValidFrom < DateTime.UtcNow));

            rightCondition =
                rightCondition.Where(x => x.ValidUntil == null || 
                    (x.ValidUntil > DateTime.UtcNow));

            rightCondition =
                rightCondition.Where(x => x.ValidUntil == null || 
                    (x.ValidUntil > DateTime.UtcNow));

            return rightCondition;
        }
    }
}
