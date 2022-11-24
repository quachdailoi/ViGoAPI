using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class DeleteBannerRequestValidator : BaseAbstractValidator<DeleteBannerRequest>
    {
        public DeleteBannerRequestValidator()
        {
            RuleFor(x => x.Ids)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");
        }
    }
}
