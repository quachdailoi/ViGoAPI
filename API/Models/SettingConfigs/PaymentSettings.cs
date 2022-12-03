namespace API.Models.SettingConfigs
{
    public class PaymentSettings
    {
        protected readonly static string BaseSection = "PaymentSettings";
        protected readonly static string Applink = $"{BaseSection}:Applink";
    }
    public class MomoSettings : PaymentSettings
    {
        private readonly static string PaymentService = "Momo";

        private readonly static string Section = $"{BaseSection}:{PaymentService}:";

        public readonly static string AccessKey = $"{Section}AccessKey";

        public readonly static string SecretKey = $"{Section}SecretKey";

        public readonly static string PublicKey = $"{Section}PublicKey";

        public readonly static string PartnerCode = $"{Section}PartnerCode";

        public readonly static string PartnerName = $"{Section}PartnerName";

        public readonly static string StoreId = $"{Section}StoreId";

        public readonly static string RedirectUrl = Applink;
    }
    public class ZaloPaySettings : PaymentSettings
    {
        private readonly static string PaymentService = "ZaloPay";

        private readonly static string Section = $"{BaseSection}:{PaymentService}:";

        public readonly static string AppId = $"{Section}AppId";

        public readonly static string Key1 = $"{Section}Key1";

        public readonly static string Key2 = $"{Section}Key2";

        public readonly static string RedirectUrl = Applink;
    }
}
