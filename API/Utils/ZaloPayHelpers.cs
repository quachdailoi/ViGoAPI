using API.Extensions;

namespace API.Utils
{
    public class ZaloPayHelpers
    {
        private static int randomNumber = new Random().Next(999999);
        public static string GetAppTransId()
        {
            
            string timeString = DateTimeOffset.Now.ToFormatString("yyMMdd_hhmmss");

            return $"{timeString}{randomNumber.ToString("D6")}";
        }
    }
}
