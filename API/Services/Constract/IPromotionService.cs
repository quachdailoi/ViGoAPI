﻿using API.Models;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IPromotionService
    {
        Task<Response> GetAvailablePromotion(int userId, Response successResponse, Response emptyResponse);
        Task<Response> GetAvailablePromotion(int userId, BookingPromotionRequest request, Response successResponse, Response emptyResponse);
        Task<Response> GetBannerPromotion(Response successResponse, Response emptyResponse);
        Task<Promotion?> GetPromotionByCode(string code, int userId, double totalPrice, int totalTickets, Payments.PaymentMethods paymentMethods);
        Task<Response> Create(CreatePromotionRequest request, Response successResponse, Response duplicateResponse, Response errorResponse);
        Task<Response> Update(int promotionId, UpdatePromotionRequest request, Response successResponse, Response notExistResponse, Response errorResponse);
        Task<List<AdminPromotionViewModel>> Get(string searchValue);
        Task<Response> Delete(List<int> ids, Response successResponse, Response notFoundResponse, Response failResponse);
    }
}
