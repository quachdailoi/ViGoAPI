namespace API.Models.Settings
{
    public class RapidApiSettings
    {
        private static string Section = "RapidApiSettings:";

        public static string TrueWayMatrixService_Uri = $"{Section}TrueWayMatrixService:Uri";

        public static string TrueWayMatrixService_ApiKey = $"{Section}TrueWayMatrixService:ApiKey";

        public static string TrueWayMatrixService_ApiHost = $"{Section}TrueWayMatrixService:ApiHost";
    }
}
