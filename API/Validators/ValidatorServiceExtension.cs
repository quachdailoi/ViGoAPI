using API.Models.Requests;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace API.Validators
{
    public static class ValidatorServiceExtension
    {
        public static void LoadAllValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<CreateRouteRoutineRequest>, CreateRouteRoutineRequestValidator>();
            services.AddScoped<IValidator<DateFilterRequest>, DateFilterRequestValidator>();
            services.AddScoped<IValidator<CreateBookingRequest>, CreateBookingRequestValidator>();
            services.AddScoped<IValidator<GetRouteFeeRequest>, GetRouteFeeRequestValidator>();
            services.AddScoped<IValidator<GetProvisionalBookingRequest>, GetProvisionalBookingRequestValidator>();
            services.AddScoped<IValidator<WalletTopUpRequest>, WalletTopUpRequestValidator>();
            services.AddScoped<IValidator<RatingAndFeedbackRequest>, RatingAndFeedBackRequestValidator>();
            services.AddScoped<IValidator<CancelBookingDetailDriversRequest>, CancelBookingDetailDriversRequestValidator>();
            services.AddScoped<IValidator<MonthFilterRequest>, MonthFilterRequestValidator>();
            //services.AddScoped<IValidator<UpdateSettingRequest>, UpdateSettingRequestValidator>();
            services.AddScoped<IValidator<CreateBannerRequest>, CreateBannerRequestValidator>();
            services.AddScoped<IValidator<UpdateBannerRequest>, UpdateBannerRequestValidator>();
            services.AddScoped<IValidator<CreatePromotionRequest>, CreatePromotionRequestValidator>();
            services.AddScoped<IValidator<UpdatePromotionRequest>, UpdatePromotionRequestValidator>();
        }
    }
}
