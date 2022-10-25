using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Notifications
    {
        public enum Types
        {
            SpecificUser,
            Booker,
            Driver,
            BookerAndDriver,
            Admin
        }

        public enum Status
        {
            Inactive,
            Active
        }
    }
}
