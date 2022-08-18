using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public enum OtpTypes
    {
        LoginOTP,
        RegisterOTP,
        VerificationOTP,
        UpdateOTP
    }

    public static class OtpTypesExtensions
    {
        public static int GetInt(this OtpTypes type)
        {
            switch (type)
            {
                case OtpTypes.LoginOTP:
                    return 0;
                case OtpTypes.RegisterOTP:
                    return 1;
                case OtpTypes.VerificationOTP:
                    return 2;
                case OtpTypes.UpdateOTP:
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
