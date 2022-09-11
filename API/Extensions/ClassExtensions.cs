namespace API.Extensions
{
    public static class ClassExtensions
    {
        public static TimeOnly ParseExact(this TimeOnly timeOnly, string s)
        {
            return TimeOnly.ParseExact(s, "HH:mm:ss");
        }

        public static DateOnly ParseExact(this DateOnly dateOnly, string s)
        {
            return DateOnly.ParseExact(s, "dd-MM-yyyy");
        }
    }
}
