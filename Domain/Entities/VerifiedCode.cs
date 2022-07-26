﻿using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VerifiedCode : BaseEntity
    {
        public DateTimeOffset? ExpiredTime { get; set; } = null;
        public string Code { get; set; } // code to verify
        public string Registration { get; set; } // email or phone
        public RegistrationTypes RegistrationType { get; set; }
        public bool Status { get; set; } = false;
        public OtpTypes Type { get; set; } // code type
    }
}
