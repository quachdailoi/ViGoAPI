namespace API.Models.Settings
{
    public class RapidApiSettings
    {
        private static string Section = "RapidApiSettings:";

        public static string ApiKeys = $"{Section}ApiKeys";

        // true way matrix
        public static string TrueWayMatrixService_Uri = $"{Section}TrueWayMatrixService:Uri";
        
        public static string TrueWayMatrixService_ApiHost = $"{Section}TrueWayMatrixService:ApiHost";

        // true way direction
        public static string TrueWayDirectionService_Uri = $"{Section}TrueWayDirectionService:Uri";

        public static string TrueWayDirectionService_ApiHost = $"{Section}TrueWayDirectionService:ApiHost";
    }
}
