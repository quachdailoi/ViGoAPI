using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Classes
{
    public class DaySchedule
    {
        public List<DayOfWeek> DaysOfWeek { get; set; } = new();
        public List<int> DaysOfMonth { get; set; } = new();
        public Dictionary<int, List<int>> IgnoreDaysByMonth { get; set; } = new();
        public Dictionary<int, List<int>> AdditionalDaysByMonth { get; set; } = new();
    }
}
