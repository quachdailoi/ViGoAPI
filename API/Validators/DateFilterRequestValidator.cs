using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class DateFilterRequestValidator : BaseAbstractValidator<DateFilterRequest>
    {
        public DateFilterRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            When(x => !string.IsNullOrEmpty(x.FromDate), () =>
            {
                RuleFor(x => x.FromDate).Must(DateOnlyTryParse);
                RuleFor(x => DateOnlyParse(x.FromDate)).GreaterThanOrEqualTo(NowDateOnly).WithName("From Date");
            });

            When(x => !string.IsNullOrEmpty(x.ToDate), () =>
            {
                RuleFor(x => x.ToDate).Must(DateOnlyTryParse);
                RuleFor(x => DateOnlyParse(x.ToDate)).GreaterThanOrEqualTo(x => DateOnlyParse(x.FromDate)).WithName("To Date");
            });
        }
    }
}
