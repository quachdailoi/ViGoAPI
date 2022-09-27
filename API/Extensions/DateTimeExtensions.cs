namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateOnly NowDateOnly => DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);
        public static bool TryParseExact(this string dateOnlyStr, out DateOnly dateOnly)
        {
            return DateOnly.TryParseExact(dateOnlyStr, "dd-MM-yyyy", out dateOnly);
        }

        public static bool TryParseExact(this string dateOnlyStr, out TimeOnly timeOnly)
        {
            return TimeOnly.TryParseExact(dateOnlyStr, "HH:mm:ss", out timeOnly);
        }

        public static DateOnly ParseExactDateOnly(string dateOnlyStr)
        {
            dateOnlyStr.TryParseExact(out DateOnly dateOnly);

            return dateOnly;
        }

        public static TimeOnly ParseExactTimeOnly(string timeOnlyStr)
        {
            timeOnlyStr.TryParseExact(out TimeOnly timeOnly);

            return timeOnly;
        }
    }
}
