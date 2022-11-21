namespace API.Models.Settings
{
    public class AwsSettings
    {
        private static string Section = "AwsSettings:";

        public static string AccessKey = $"{Section}AccessKey";

        public static string SecretKey = $"{Section}SecretKey";

        public static string UserAvatarFolder = $"{Section}UserAvatarFolder";

        public static string IdentiticationFolder = $"{Section}IdentiticationFolder";

        public static string DriverLicenseFolder = $"{Section}DriverLicenseFolder";

        public static string VehicleRegistrationFolder = $"{Section}VehicleRegistrationFolder";

        public static string DriverRegistrationFolder = $"{Section}DriverRegistrationFolder";

        public static string BannerFolder = $"{Section}BannerFolder";

        public static string BucketName = $"{Section}BucketName";

        public static string RegionEndPoint = $"{Section}RegionEndPoint";

        public static string DefaultAvatar = $"{Section}DefaultAvatar";
    }
}
