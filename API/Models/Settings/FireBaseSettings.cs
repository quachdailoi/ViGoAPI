namespace API.Models.Settings
{
    public class FireBaseSettings
    {
        private static string Section = "Firebase:";
        public static string ProjectId = $"{Section}ProjectId";
        public static string ServiceAccountId = $"{Section}ServiceAccountId";
        public static string AdminSdkJsonFile = $"{Section}AdminSdkJsonFile";
    }
}
