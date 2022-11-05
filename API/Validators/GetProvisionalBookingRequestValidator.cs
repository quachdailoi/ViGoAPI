using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class GetProvisionalBookingRequestValidator : BaseAbstractValidator<GetProvisionalBookingRequest>
    {
        public GetProvisionalBookingRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.RouteCode)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");

            RuleFor(x => x.VehicleTypeCode)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");

            RuleFor(x => x.StartStationCode)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");

            RuleFor(x => x.EndStationCode)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");

            RuleFor(x => x.StartAt)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null")
                .Must(DateOnlyTryParse)
                .WithMessage("{PropertyName} is invalid date")
                .DependentRules(() =>
                {
                    RuleFor(x => DateOnlyParse(x.StartAt))
                        .GreaterThanOrEqualTo(NowDateOnly)
                        .WithMessage("Start at must not be before now");
                });

            RuleFor(x => x.EndAt)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null")
                .Must(DateOnlyTryParse)
                .WithMessage("{PropertyName} is invalid date")
                .DependentRules(() =>
                {
                    RuleFor(x => DateOnlyParse(x.EndAt))
                        .GreaterThanOrEqualTo(x => DateOnlyParse(x.StartAt))
                        .WithMessage("End at must not be before start at");
                });

            RuleFor(x => x.Time)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null")
                .Must(TimeOnlyTryParse)
                .WithMessage("{PropertyName} is invalid time")
                .DependentRules(() =>
                {
                    RuleFor(x => ToDateTime(x.StartAt, x.Time))
                        .GreaterThan(DateTimeOffset.Now)
                        .WithMessage("Time has passed");
                });

            RuleFor(x => x.DayOfWeeks)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");
        }
    }
}
