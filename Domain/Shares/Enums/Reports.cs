using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Reports
    {
        public enum Status
        {
            Pending = 0,
            Processced = 1,
            ProcessingDenied = 2
        }

        public enum Types
        {
            DriverNotComming = 1,
            BookerNotComming = 2
        }
    }
}
