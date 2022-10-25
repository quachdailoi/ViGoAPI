using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Description { get; set; } = string.Empty;
        public Notifications.Types Type { get; set; }
        public object? Data { get; set; } = null;
        public Notifications.Status Status { get; set; } = Notifications.Status.Active;
        public int? UserId { get; set; } = null;
        public Events.Types EventId { get; set; }

        public User? User { get; set; } = null;
        public Event Event { get; set; }
    }
}
