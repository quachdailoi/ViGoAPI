using Domain.Entities.Base;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        public int UserId { get; set; }
        public string Registration { get; set; } // gmail or phone number
        public RegistrationTypes RegistrationType { get; set; } // email: 0 or phone number: 1
        public bool Verified { get; set; } = false;
        public Roles? RoleId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
