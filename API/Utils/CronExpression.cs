namespace API.Utils
{
    public class CronExpression
    {
        public static string ParseFromSpecificDatetime(DateTime dateTime)
        {
            return $"{dateTime.Second} {dateTime.Minute} {dateTime.Hour} {dateTime.Date} {dateTime.Month} ? {dateTime.Year}";
        }

        public static string ParseFromSpecificTimeOnlyDaily(TimeOnly timeOnly)
        {
            return $"{timeOnly.Second} {timeOnly.Minute} {timeOnly.Hour} * * ?";
        }
    }
}
