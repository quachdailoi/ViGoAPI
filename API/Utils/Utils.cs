using Newtonsoft.Json;

namespace API.Utils
{
    public static class Utils
    {
        public static Dictionary<string, TValue>? ToDictionary<TValue>(object? obj)
        {
            if (obj == null) return null;
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
            return dictionary;
        }
    }
}
