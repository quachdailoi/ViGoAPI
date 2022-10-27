using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        public Events.Types Id { get; set; }
        public string Tittle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Events.SubTypes Type { get; set; }
        public Events.Status Status { get; set; } = Events.Status.Active;

        public List<Notification> Notifications { get; set; } = new();
    }
}
