using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public enum VerifiedCodeTypes
    {
        LoginOTP,
        RegisterOTP,
        VerificationOTP
    }

    public static class VerifiedCodeTypesExtensions
    {
        public static int GetInt(this VerifiedCodeTypes type)
        {
            switch (type)
            {
                case VerifiedCodeTypes.LoginOTP:
                    return 0;
                case VerifiedCodeTypes.RegisterOTP:
                    return 1;
                case VerifiedCodeTypes.VerificationOTP:
                    return 2;
                default:
                    return -1;
            }
        }
    }
}
