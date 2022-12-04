using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Setting
    {
        public Settings Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public SettingTypes TypeId { get; set; } = SettingTypes.Default;
        public SettingDataTypes DataTypeId { get; set; } = SettingDataTypes.Default;
        public SettingDataUnits DataUnitId { get; set; } = SettingDataUnits.Default;

        public SettingType Type { get; set; } 
        public SettingDataType DataType { get; set; }
        public SettingDataUnit DataUnit { get; set; }
    }
}
