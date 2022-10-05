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
        }
    }
}
