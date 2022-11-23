using API.Models.Requests;
using API.Services.Constract;
using Domain.Shares.Enums;
using FluentValidation;

namespace API.Validators
{
    public class UpdatePromotionRequestValidator : BaseAbstractValidator<UpdatePromotionRequest>
    {
        public UpdatePromotionRequestValidator(IAppServices appServices)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            var fileSizeLimit = appServices.Setting.GetValue<int>(Domain.Shares.Enums.Settings.PromotionFileSizeLimit, 20).Result;

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .MaximumLength(10)
                .WithMessage("{PropertyName}'s length is not exceed 10 characters")
                .When(x => x.Code != null);


            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null")
                .MaximumLength(30)
                .WithMessage("{PropertyName}'s length is not exceed 30 characters");

            RuleFor(x => x.Details)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");

            RuleFor(x => x.DiscountPercentage)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null")
                .ExclusiveBetween(0, 1)
                .WithMessage("{PropertyName} must from 0 to 1");

            RuleFor(x => x.MaxDecrease)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must greater than or equal to 0");

            RuleFor(x => x.Type)
                .Must(x => (int)x >= (int)Promotions.Types.Holiday && (int)x <= (int)Promotions.Types.MoreAndMore)
                .NotNull()
                .WithMessage("{PropertyName} must be not null");

            RuleFor(x => x.TotalUsage)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must greater than or equal to 0")
                .When(x => x.TotalUsage.HasValue);

            RuleFor(x => x.UsagePerUser)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must greater than or equal to 0")
                .When(x => x.TotalUsage.HasValue);

            RuleFor(x => x.MinTotalPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must greater than or equal to 0")
                .When(x => x.TotalUsage.HasValue);

            RuleFor(x => x.MinTickets)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must greater than or equal to 0")
                .When(x => x.TotalUsage.HasValue);

            RuleFor(x => x.ValidFrom)
                .Must(DatetimeTryParse)
                .When(x => !string.IsNullOrEmpty(x.ValidFrom))
                .WithMessage("{PropertyName} has wrong format (dd-MM-yyyy HH:mm:ss)");

            RuleFor(x => x.ValidUntil)
                .Must(DatetimeTryParse)
                .When(x => !string.IsNullOrEmpty(x.ValidUntil))
                .WithMessage("{PropertyName} has wrong format (dd-MM-yyyy HH:mm:ss)");

            When(x => !string.IsNullOrEmpty(x.ValidFrom) && !string.IsNullOrEmpty(x.ValidUntil), () =>
            {
                RuleFor(x => DatetimeParse(x.ValidUntil))
                    .GreaterThanOrEqualTo(x => DatetimeParse(x.ValidFrom))
                    .WithMessage("ValidUntil must be equal or after ValidFrom");
            });


            RuleFor(x => x.File)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null")
                .Must(x => CheckFileSize(x, fileSizeLimit))
                .WithMessage("{PropertyName}'s size exceeded " + $"{fileSizeLimit}MB.")
                .When(x => x.File != null);
        }

        private bool CheckFileSize(IFormFile file, int fileSizeLimit)
        {
            try
            {
                file.CheckFileSize(file.FileName, fileSizeLimit);
            }
            catch { return false; }

            return true;
        }
    }
}
