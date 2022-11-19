using API.Extensions;
using API.Models.Response;
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

        public async Task<Response> GetAll(Response response)
        {
            var settings = (await UnitOfWork.Settings
                .List(x => x.Type != null)
                .ToListAsync())
                .GroupBy(x => x.Type)
                .Select(x => new
                {
                    Type = x.Key.Value,
                    TypeName = x.Key.Value.DisplayName(),
                    Settings = x.Select(setting => new
                    {
                        Id = setting.Id,
                        Key = setting.Key,
                        Value = setting.Value
                    })
                });

            return response.SetData(settings);
        }

        public async Task<bool> Update(Dictionary<Settings,string> items)
        {
            var settings = await UnitOfWork.Settings
                .List(x => items.Keys.Contains(x.Id))
                .ToListAsync();

            foreach(var setting in settings)
            {
                setting.Value = items[setting.Id];
            }

            if (!await UnitOfWork.Settings.UpdateRange(settings.ToArray()))
                return false;

            foreach (var setting in settings)
            {
                await Cache.SetStringAsync($"Setting:{setting.Id.DisplayName()}", setting.Value);
            }

            return true;
        }

        public async Task<string?> GetValue(Settings key) 
        {
            var value = await Cache.GetStringAsync($"Setting:{key.DisplayName()}");

            if(value == null)
            {
                var setting = await UnitOfWork.Settings.List(setting => setting.Id == key).FirstOrDefaultAsync();

                if (setting == null)
                    return null;

                value = setting.Value;

                await Cache.SetStringAsync($"Setting:{key.DisplayName()}", value);
            }
            return value;
        }
        
        public async Task<T> GetValue<T>(Settings key, T defaultValue)
        {
            dynamic? setting = await GetValue(key);
            if (setting == null) return defaultValue;

            if(typeof(T).IsAssignableFrom(typeof(TimeOnly)))
            {
                setting = TimeOnly.Parse(setting);
            }

            return (T)Convert.ChangeType(setting, typeof(T));
        }
    }
}
