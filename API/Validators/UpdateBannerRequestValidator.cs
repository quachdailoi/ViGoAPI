using API.Models.Requests;
using API.Services.Constract;
using FluentValidation;

namespace API.Validators
{
    public class UpdateBannerRequestValidator : BaseAbstractValidator<UpdateBannerRequest>
    {
        public UpdateBannerRequestValidator(IAppServices appServices)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            var fileSizeLimit = appServices.Setting.GetValue<int>(Domain.Shares.Enums.Settings.BannerFileSizeLimit, 20).Result;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");


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
                .Cascade(CascadeMode.Stop)
                .Must(file => CheckFileSize(file, fileSizeLimit))
                .WithMessage("{PropertyName}'s size exceeded " + $"{fileSizeLimit}MB.")
                .When(file => file != null);                    
        }

        private bool CheckFileSize(IFormFile file, int fileSizeLimit)
        {
            try
            {
                file.ValideSize(file.FileName, fileSizeLimit);
            }
            catch { return false; }

            return true;
        }
    }
}
