namespace API.Models.SettingConfigs
{
    public class FireBaseSettings
    {
        private static string Section = "FirebaseSettings:";
        public static string ProjectId = $"{Section}ProjectId";
        public static string ServiceAccountId = $"{Section}ServiceAccountId";
        public static string AdminSdkJsonFile = $"{Section}AdminSdkJsonFile";
    }
}
