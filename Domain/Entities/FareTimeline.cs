﻿using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FareTimeline : BaseEntity
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        [JsonIgnore]
        public int FareId { get; set; }
        public double ExtraFeePerKm { get; set; }
        public double CeilingExtraPrice { get; set; }

        [JsonIgnore]
        public Fare Fare { get; set; }
    }
}
