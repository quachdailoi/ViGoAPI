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

        public static DateTime ParseExactDateTime(string dateOnlyStr, string timeOnlyStr)
        {
            dateOnlyStr.TryParseExact(out DateOnly dateOnly);
            timeOnlyStr.TryParseExact(out TimeOnly timeOnly);

            return dateOnly.ToDateTime(timeOnly);
        }

        public static bool CheckIntersect(DateOnly start1, DateOnly end1, DateOnly start2, DateOnly end2)
        {
            return start1 <= end2 && end1 >= start2;
        }

        public static bool CheckIntersect(TimeOnly start1, TimeOnly end1, TimeOnly start2, TimeOnly end2)
        {
            return start1 <= end2 && end1 >= start2;
        }

        public static TimeOnly RoundUp(this TimeOnly time, int minutes = 30)
        {
            if (time.Minute <= minutes) return new TimeOnly(time.Hour, minutes);

            return new TimeOnly(time.Hour + 1, 0);
        }
    }
}
