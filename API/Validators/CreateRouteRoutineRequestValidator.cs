using API.Extensions;
using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class CreateRouteRoutineRequestValidator : BaseAbstractValidator<CreateRouteRoutineRequest>
    {
        public CreateRouteRoutineRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.RouteCode).NotEmpty().NotNull();

            RuleFor(x => x.StartAt).Cascade(CascadeMode.Stop).Must(DateOnlyTryParse).NotEmpty().NotNull();
            RuleFor(x => DateOnlyParse(x.StartAt)).GreaterThanOrEqualTo(NowDateOnly).WithName("Start At");

            RuleFor(x => x.EndAt).Must(DateOnlyTryParse).NotEmpty().NotNull();
            RuleFor(x => DateOnlyParse(x.EndAt)).GreaterThanOrEqualTo(x => DateOnlyParse(x.StartAt)).WithName("End At");

            RuleFor(x => x.StartTime).Must(TimeOnlyTryParse).NotEmpty().NotNull();
        }
    }
}
