using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class CancelBookingDetailDriversRequestValidator : BaseAbstractValidator<CancelBookingDetailDriversRequest>
    {
        public CancelBookingDetailDriversRequestValidator()
        {
            RuleFor(x => x.BookingDetailDriverCodes)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");

            RuleFor(x => x.Reason)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");
        }
    }
}
