using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface ISettingService
    {
        Task<string?> GetValue(Settings key);
    }
}
