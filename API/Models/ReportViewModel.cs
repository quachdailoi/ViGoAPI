using API.Extensions;
using Domain.Shares.Enums;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class ReportViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public object? Data { get; set; } = null;
        public Reports.Types Type { get; set; }
        public string TypeName { get => Type.DisplayName(); }
        public Reports.Status Status { get; set; }
        public string StatusName { get => Status.DisplayName(); }
        public DateTimeOffset DateTime { get; set; }

        public ContactUserViewModel User { get; set; }
        public ContactUserViewModel? UpdatedAdmin { get; set; } = null;

        public virtual T? GetData<T>()
        {
            dynamic data;

            try
            {
                data = JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(Data));
            }
            catch
            {
                if (typeof(T).IsAssignableTo(typeof(Guid)))
                {
                    data = Guid.Parse((string)JsonValue.Parse(Data.ToString()));
                }
                else
                {
                    data = (T)Convert.ChangeType((string)Data, typeof(T));
                }

            }
            return data;
        }
    }
}
