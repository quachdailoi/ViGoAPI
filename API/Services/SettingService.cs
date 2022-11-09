using API.Services.Constract;
using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace API.Services
{
    public class SettingService : BaseService, ISettingService
    {
        public SettingService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<string?> GetValue(Settings key) 
        {
            var value = await Cache.GetStringAsync($"Setting:{key}");

            if(value == null)
            {
                var setting = await UnitOfWork.Settings.List(setting => setting.Id == key).FirstOrDefaultAsync();

                if (setting == null)
                    return null;

                value = setting.Value;

                await Cache.SetStringAsync($"Setting:{key}", value);
            }
            return value;
        }
        
        public async Task<T> GetValue<T>(Settings key, T defaultValue)
        {
            var setting = await GetValue(key);
            if (setting == null) return defaultValue;

            return (T)Convert.ChangeType(setting, typeof(T));
        }
    }
}
