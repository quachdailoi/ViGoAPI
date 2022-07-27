using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public enum RegistrationTypes
    {
        Email,
        Phone
    }

    public static class RegistrationTypesExtensions
    {
        public static int GetInt(this RegistrationTypes type)
        {
            switch (type)
            {
                case RegistrationTypes.Email:
                    return 0;
                case RegistrationTypes.Phone:
                    return 1;
                default:
                    return -1;
            }
        }
    }
}
