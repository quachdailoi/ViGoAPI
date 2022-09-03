﻿namespace API.Models.Settings
{
    public class AwsSettings
    {
        private static string Section = "AwsSettings:";

        public static string AccessKey = $"{Section}AccessKey";

        public static string SecretKey = $"{Section}SecretKey";

        public static string UserAvatarFolder = $"{Section}UserAvatarFolder";

        public static string BucketName = $"{Section}BucketName";

        public static string RegionEndPoint = $"{Section}RegionEndPoint";

        public static string DefaultAvatar = $"{Section}DefaultAvatar";
    }
}