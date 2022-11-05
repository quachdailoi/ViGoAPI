using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pricing : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public int? LowerBound { get; set; } = null;
        public int? UpperBound { get; set; } = null;
        public double Discount { get; set; }
    }
}
