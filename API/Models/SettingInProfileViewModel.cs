using Domain.Shares.Enums;

namespace API.Models
{
    public class SettingInProfileViewModel
    {
        public Settings Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public SettingDataTypes DataType { get; set; }
        public string DataTypeName { get; set; }
        public string Unit { get; set; }
    }
}
