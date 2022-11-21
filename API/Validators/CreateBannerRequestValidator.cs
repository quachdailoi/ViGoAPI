using API.Models.Requests;
using API.Services.Constract;
using FluentValidation;

namespace API.Validators
{
    public class CreateBannerRequestValidator : BaseAbstractValidator<CreateBannerRequest>
    {
        public CreateBannerRequestValidator(IAppServices appServices)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            var fileSizeLimit = appServices.Setting.GetValue<int>(Domain.Shares.Enums.Settings.BannerFileSizeLimit, 20).Result;

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");


            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");

            RuleFor(x => x.File)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null")
                .Must(x => CheckFileSize(x, fileSizeLimit))
                .WithMessage("{PropertyName}'s size exceeded "+$"{fileSizeLimit}MB.");
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
