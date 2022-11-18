using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class MonthFilterRequestValidator : BaseAbstractValidator<MonthFilterRequest>
    {
        public MonthFilterRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            When(x => !string.IsNullOrEmpty(x.FromMonth), () =>
            {
                RuleFor(x => $"01-{x.FromMonth}").Must(DateOnlyTryParse);
            });

            When(x => !string.IsNullOrEmpty(x.ToMonth), () =>
            {
                RuleFor(x => $"01-{x.ToMonth}").Must(DateOnlyTryParse);
                RuleFor(x => DateOnlyParse($"01-{x.ToMonth}")).GreaterThanOrEqualTo(x => DateOnlyParse($"01-{x.FromMonth}"));
            });
        }
    }
}
