using API.Models.Response;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface ISettingService
    {
        Task<string?> GetValue(Settings key);
        Task<T> GetValue<T>(Settings key, T defaultValue);
        Task<Response> GetAll(Response response);
        Task<bool> Update(Dictionary<Settings, string> items);
    }
}
