namespace API.Models.Requests
{
    public class UpdateSettingRequest
    {
        public Dictionary<Domain.Shares.Enums.Settings, string> Settings { get; set; }
    }
}
