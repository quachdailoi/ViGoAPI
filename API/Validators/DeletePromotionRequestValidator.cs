using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class DeletePromotionRequestValidator : BaseAbstractValidator<DeletePromotionRequest>
    {
        public DeletePromotionRequestValidator()
        {
            RuleFor(x => x.Ids)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");
        }
    }
}
