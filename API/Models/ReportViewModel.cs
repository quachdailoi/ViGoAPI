using API.Extensions;
using Domain.Shares.Enums;
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
        [JsonIgnore]
        public object? Data { get; set; } = null;
        public Reports.Types Type { get; set; }
        public string TypeName { get => Type.DisplayName(); }
        public Reports.Status Status { get; set; }
        public string StatusName { get => Status.DisplayName(); }

        public ContactUserViewModel User { get; set; }
    }
}
