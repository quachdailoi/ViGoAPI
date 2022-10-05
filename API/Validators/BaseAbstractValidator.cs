using API.Extensions;
using FluentValidation;
using FluentValidation.Results;

namespace API.Validators
{
    public class BaseAbstractValidator<T> : AbstractValidator<T>
    {
        protected DateOnly NowDateOnly => DateTimeExtensions.NowDateOnly;

        protected bool DateOnlyTryParse(string dateOnlyStr, out DateOnly date)
        {
            return DateTimeExtensions.TryParseExact(dateOnlyStr, out date);
        }

        protected bool TimeOnlyTryParse(string timeOnlyStr, out TimeOnly time)
        {
            return DateTimeExtensions.TryParseExact(timeOnlyStr, out time);
        }

        protected bool TimeOnlyTryParse(string timeStr)
        {
            TimeOnly time;
            var x = DateTimeExtensions.TryParseExact(timeStr, out time);
            return x;
        }

        protected bool DateOnlyTryParse(string? timeStr)
        {
            DateOnly date;
            if (timeStr == null) return true;
            var x = DateTimeExtensions.TryParseExact(timeStr, out date);
            return x;
        }

        protected DateOnly? DateOnlyParse(string dateOnlyString)
        {
            return new DateOnly().ParseExact(dateOnlyString);
        }

        protected TimeOnly TimeOnlyParse(string timeOnlyString)
        {
            return new TimeOnly().ParseExact(timeOnlyString);
        }

        public override ValidationResult Validate(ValidationContext<T> context)
        {
            var validationResult = base.Validate(context);
            
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors[0].ErrorMessage);
            }

            return validationResult;
        }
    }
}
