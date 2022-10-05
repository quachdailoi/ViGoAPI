using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class GetRouteFeeRequestValidator : BaseAbstractValidator<GetRouteFeeRequest>
    {
        public GetRouteFeeRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.StartStationCode)
                .NotEmpty()
                .WithMessage("Must be not empty")
                .NotNull()
                .WithMessage("Must be not null");

            RuleFor(x => x.EndStationCode)
                .NotEmpty()
                .WithMessage("Must be not empty")
                .NotNull()
                .WithMessage("Must be not null");

            RuleFor(x => x.VehicleTypeCode)
                .NotEmpty()
                .WithMessage("Must be not empty")
                .NotNull()
                .WithMessage("Must be not null");

            RuleFor(x => x.StartAt)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Must be not empty")
                .NotNull()
                .WithMessage("Must be not null")
                .Must(DateOnlyTryParse)
                .WithMessage("Invalid date")
                .DependentRules(() =>
                {
                    RuleFor(x => DateOnlyParse(x.StartAt))
                        .GreaterThanOrEqualTo(NowDateOnly)
                        .WithMessage("Start at must not be before now");
                });

            RuleFor(x => x.EndAt)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Must be not empty")
                .NotNull()
                .WithMessage("Must be not null")
                .Must(DateOnlyTryParse)
                .WithMessage("Invalid date")
                .DependentRules(() =>
                {
                    RuleFor(x => DateOnlyParse(x.EndAt))
                        .GreaterThanOrEqualTo(x => DateOnlyParse(x.StartAt))
                        .WithMessage("End at must not be before start at");
                });

            RuleFor(x => x.Time)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Must be not empty")
                .NotNull()
                .WithMessage("Must be not null")
                .Must(TimeOnlyTryParse)
                .WithMessage("Invalid time")
                .DependentRules(() =>
                {
                    RuleFor(x => ToDateTime(x.StartAt, x.Time))
                        .GreaterThan(DateTimeOffset.Now)
                        .WithMessage("Time has passed");
                });
        }
    }
}
