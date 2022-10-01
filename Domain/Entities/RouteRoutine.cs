﻿using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RouteRoutine : BaseEntity
    {
        public int RouteId { get; set; }
        public int UserId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public RouteRoutines.Status Status { get; set; }

        public Route Route { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}