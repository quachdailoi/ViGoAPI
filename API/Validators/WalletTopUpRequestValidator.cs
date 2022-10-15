using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class WalletTopUpRequestValidator : BaseAbstractValidator<WalletTopUpRequest>
    {
        public WalletTopUpRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Amount)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null")
                .GreaterThan(1000)
                .WithMessage("{PropertyName} must be greater than or equal 1000");

            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");
        }
    }
}
