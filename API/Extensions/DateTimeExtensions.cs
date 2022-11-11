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
        public static string ToFormatString(this DateOnly dateOnly, string format) => dateOnly.ToString(format); 

        public static List<DateOnly> ToDates(this DateOnly dateOnly1, DateOnly dateOnly2, List<DayOfWeek> dayOfWeeks)
        {
            var fromDate = dateOnly1 <= dateOnly2 ? dateOnly1 : dateOnly2;
            var toDate = dateOnly1 > dateOnly2 ? dateOnly1 : dateOnly2;

            List<DateOnly> dates = new();

            for(var date = fromDate; date <= toDate; date = date.AddDays(1))
            {
                if (dayOfWeeks.Contains(date.DayOfWeek))
                    dates.Add(date);
            }

            return dates;
        }

        public static DateTime ParseExactDateTime(string dateOnlyStr, string timeOnlyStr)
        {
            dateOnlyStr.TryParseExact(out DateOnly dateOnly);
            timeOnlyStr.TryParseExact(out TimeOnly timeOnly);

            return dateOnly.ToDateTime(timeOnly);
        }

        public static string ToFormatString(this DateTimeOffset dateTime) => dateTime.ToString("dd-MM-yyyy HH:mm:ss");
        public static string ToFormatString(this DateTimeOffset dateTime, string format) => dateTime.ToString(format);

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
            if (minutes > 60) throw new Exception("Minute round must lower than 60.");
            var hour = time.Hour;
            var minute = time.Minute;

            if (minute % minutes == 0) return time;

            for (var i = 1; i <= (60 / minutes)+1; i++) 
            {
                if (minutes * i >= 60)
                {
                    hour += 1;
                    minute = minutes * i - 60;
                    return new TimeOnly(hour, minute);
                }

                if (minute < minutes * i) return new TimeOnly(hour, minutes * i);
            }

            return new TimeOnly(time.Hour + 1, 0);
        }

        public static TimeOnly RoundDown(this TimeOnly time, int minutes = 30)
        {
            if (minutes > 60) throw new Exception("Minute round must lower than 60.");
            var hour = time.Hour;
            var minute = time.Minute;

            if (minute % minutes == 0) return time;

            for (var i = 1; i <= (60 / minutes) + 1; i++)
            {
                if (minute < minutes * i) return new TimeOnly(hour, minutes * (i-1));
            }

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
