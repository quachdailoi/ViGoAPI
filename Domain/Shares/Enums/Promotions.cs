using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Promotions
    {
        public enum Status
        {
            Unavailable = 0,
            Available = 1
        }

        public enum Types
        {
            Holiday = 0,
            MoreAndMore = 1,
            NewUser = 2
        }
    }
}
