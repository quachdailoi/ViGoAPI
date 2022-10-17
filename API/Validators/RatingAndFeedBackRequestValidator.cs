using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class RatingAndFeedBackRequestValidator : BaseAbstractValidator<RatingAndFeedbackRequest>
    {
        public RatingAndFeedBackRequestValidator()
        {
            RuleFor(x => x.Rating)
                .Must(ValidateRating)
                .WithMessage("{PropertyName} must between 0 and 5 if it's not null.");
        }

        private bool ValidateRating(double? rating)
        {
            if (rating != null && rating < 0 && rating > 5) return false;

            return true;
        }
    }
}
