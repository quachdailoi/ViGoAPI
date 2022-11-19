using API.Extensions;

namespace API.Models.Requests
{
    public class MonthFilterRequest
    {
        public string? FromMonth { get; set; } = null;
        public string? ToMonth { get; set; } = null;
        public DateOnly? FromMonthParsed() => FromMonth != null ? DateTimeExtensions.ParseExactDateOnly("01-" + FromMonth) : null;
        public DateOnly? ToMonthParsed() 
        {
            if (ToMonth == null) return null;

            var split = ToMonth.Split("-");

            var month = int.Parse(split[0]);
            var year = int.Parse(split[1]);


            return DateTimeExtensions.ParseExactDateOnly(DateTime.DaysInMonth(year, month).ToString().PadLeft(2, '0') + "-" + ToMonth);

        }
    }
}
