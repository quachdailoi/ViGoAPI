namespace API.Models.Settings
{
    public abstract class PaymentSettings
    {
        protected static string? PaymentService;
        protected static string Section = $"PaymentSettings:{PaymentService}:";
        public static string AccessKey = $"{Section}AccessKey";
        public static string SecretKey = $"{Section}SecretKey";
        public static string PublicKey = $"{Section}PublicKey";
        //public abstract void SetPaymentService();
    }

    public class MomoSettings : PaymentSettings
    {
        public static string PartnerCode = $"{Section}PartnerCode";
        public static string PartnerName = $"{Section}PartnerName";
        public static string StoreId = $"{Section}StoreId";
        MomoSettings()
        {
            PaymentService = "Momo";
        }
    }
}
