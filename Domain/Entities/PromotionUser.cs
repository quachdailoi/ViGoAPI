using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PromotionUser : BaseEntity
    {
        public int PromotionId { get; set; }
        public int UserId { get; set; }
        public int Used { get; set; } = 0;
        public DateTime? ExpiredTime { get; set; }

        public Promotion Promotion { get; set; }
        public User User { get; set; }
    }
}
