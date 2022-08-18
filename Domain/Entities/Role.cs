using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role 
    {
        public Roles Id { get; set; }
        public string Description { get; set; } 
        public string Name { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
