using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid Code { get; set; } = new();
        public string Name { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; } = 1;
        public DateTime DateOfBirth { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
