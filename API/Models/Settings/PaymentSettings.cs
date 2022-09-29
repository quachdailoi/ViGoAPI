namespace API.Models.Settings
{
    public class PaymentSettings
    {
        public static string PaymentService;
        public static string Section = $"PaymentSettings:{PaymentService}:";
        public static string AccessKey = $"{Section}AccessKey";
        public static string SecretKey = $"{Section}SecretKey";
        public static string PublicKey = $"{Section}PublicKey";
        //public abstract void SetPaymentService();
    }

    public class MomoSettings : PaymentSettings
    {    
        protected new static string PaymentService = "Momo";
        protected new static string Section = $"PaymentSettings:{PaymentService}:";
        public static new string AccessKey = $"{Section}AccessKey";
        public static new string SecretKey = $"{Section}SecretKey";
        public static new string PublicKey = $"{Section}PublicKey";
        public static new string PartnerCode = $"{Section}PartnerCode";
        public static new string PartnerName = $"{Section}PartnerName";
        public static new string StoreId = $"{Section}StoreId";
    }
}
