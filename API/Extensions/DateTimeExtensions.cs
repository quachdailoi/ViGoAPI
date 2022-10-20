namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateOnly NowDateOnly => DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);
        public static TimeOnly NowTimeOnly => TimeOnly.FromTimeSpan(DateTimeOffset.Now.TimeOfDay);
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

        public static string ToFormatString(this DateOnly dateOnly) => dateOnly.ToString("dd-MM-yyyy"); 

        public static DateTime ParseExactDateTime(string dateOnlyStr, string timeOnlyStr)
        {
            dateOnlyStr.TryParseExact(out DateOnly dateOnly);
            timeOnlyStr.TryParseExact(out TimeOnly timeOnly);

            return dateOnly.ToDateTime(timeOnly);
        }

        public static string ToFormatString(this DateTimeOffset dateTime) => dateTime.ToString("dd-MM-yyyy HH:mm:ss");

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

        public static TimeSpan ToTimeSpan(this TimeOnly time1, TimeOnly time2)
        {
            if (time1.CompareTo(time2) <= 0)
                return time2 - time1;

            return time1 - time2;
        }
    }
}
