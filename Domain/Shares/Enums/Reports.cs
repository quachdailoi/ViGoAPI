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
            Pending = 1,
            Processced = 2,
            ProcessingDenied = 3 
        }

        public enum Types
        {
            DriverNotComming = 1,
            BookerNotComming = 2
        }
    }
}
