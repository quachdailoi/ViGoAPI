using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SettingDataUnit
    {
        public SettingDataUnits Id { get; set; }
        public string Name { get; set; }

        public List<Setting> Settings { get; set; }
    }
}
