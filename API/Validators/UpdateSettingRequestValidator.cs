using API.Extensions;
using API.Models.Requests;
using Domain.Shares.Enums;
using FluentValidation;

namespace API.Validators
{
    public class UpdateSettingRequestValidator : BaseAbstractValidator<UpdateSettingRequest>
    {
        public UpdateSettingRequestValidator()
        {
            var errorMsg = "Bad request";

            RuleFor(x => x.Settings)
                .NotEmpty()
                .WithMessage("{PropertyName} must be not empty")
                .NotNull()
                .WithMessage("{PropertyName} must be not null");

            RuleForEach(x => x.Settings)
                .Must(x => ValidateSettingValue(x.Key, x.Value, out errorMsg))
                .WithMessage("{PropertyName} is invalid format value");
                //.WithMessage(errorMsg);

        }

        public static bool ValidateSettingValue(Settings key, string value, out string errorMsg)
        {
            errorMsg = string.Empty;
            switch (key)
            {
                case Settings.TradeDiscount:
                case Settings.MaxCancelledTripRate:
                case Settings.NotifiedCancelledTripRate:
                case Settings.DiscountPerEachSharingCase:
                case Settings.ThresholdDiscountPerEachSharingCase:
                case Settings.TradeDisountForBookerCancelTrip:
                    if (double.TryParse(value, out var doubleParsedValue))
                    {
                        if(doubleParsedValue < 0 || doubleParsedValue > 1)
                        {
                            errorMsg = $"{key.DisplayName()} must be a double value between 0% and 100%";
                            return false;
                        }
                    }
                    else
                    {
                        errorMsg = $"{key.DisplayName()} must be a double value between 0% and 100%";
                        return false;
                    }
                    break;
                case Settings.TimeAfterComplete:
                case Settings.TimeBeforeToPickUp:
                case Settings.TimeRatingAfterComplete:
                case Settings.TotalTripsCalculateRating:
                case Settings.RadiusNearbyStation:
                case Settings.RadiusToComplete:
                case Settings.LastDayNumberForNextMonthRoutine:
                case Settings.AllowedCancelAfterCreateBookingTime:
                    if (int.TryParse(value, out var intParsedValue))
                    {
                        if (intParsedValue < 0)
                        {
                            errorMsg = $"{key.DisplayName()} must be an integer value greater than or equal 0";
                            return false;
                        }
                    }
                    else
                    {
                        errorMsg = $"{key.DisplayName()} must be an integer value greater than or equal 0";
                        return false;
                    }
                    break;
                case Settings.CheckingMappingStatusTime:
                case Settings.NotifyTripInDayTime:
                case Settings.AllowedDriverCancelTripTime:
                case Settings.TimeToCreateTomorrowRoutine:
                case Settings.AllowedBookerCancelTripTime:
                    if (!value.TryParseExact(out TimeOnly timeOnly))
                    {
                        errorMsg = $"{key.DisplayName()} must be a time value (hh:mm:ss)";
                        return false;
                    }
                    break;
                default:
                    errorMsg = "Key is not exist.";
                    return false;
                
            }

            return true;
        }
    }
}
