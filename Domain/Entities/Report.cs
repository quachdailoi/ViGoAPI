using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Report : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public object? Data { get; set; } = null;
        public Reports.Types Type { get; set; }
        public Reports.Status Status { get; set; } = Reports.Status.Pending;
        
        public User User { get; set; }

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
