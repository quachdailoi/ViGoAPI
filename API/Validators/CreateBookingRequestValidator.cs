using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class CreateBookingRequestValidator : BaseAbstractValidator<CreateBookingRequest>
    {
        public CreateBookingRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.StartStationCode).NotNull().NotEmpty();
        }
    }
}
