namespace API.Models.Settings
{
    public class MomoSettings
    {    
        private readonly static string PaymentService = "Momo";

        private readonly static string Section = $"PaymentSettings:{PaymentService}:";

        public readonly static string AccessKey = $"{Section}AccessKey";

        public readonly static string SecretKey = $"{Section}SecretKey";

        public readonly static string PublicKey = $"{Section}PublicKey";

        public readonly static string PartnerCode = $"{Section}PartnerCode";

        public readonly static string PartnerName = $"{Section}PartnerName";

        public readonly static string StoreId = $"{Section}StoreId";
    }
}
