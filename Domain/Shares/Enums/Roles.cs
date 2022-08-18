using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public enum Roles
    {
        BOOKER = 1,
        DRIVER = 2,
        ADMIN = 3,
        GUEST = 4,
    }

    public static class RolesExtensions
    {
        public static string GetString(this Roles role)
        {
            switch (role)
            {
                case Roles.BOOKER:
                    return "BOOKER";
                case Roles.DRIVER:
                    return "DRIVER";
                case Roles.ADMIN:
                    return "ADMIN";
                default:
                    return "GUEST";
            }
        }

        public static string GetName(this Roles role)
        {
            return Enum.GetName(typeof(Roles), role);
        }

        public static int GetInt(this Roles role)
        {
            switch (role)
            {
                case Roles.BOOKER:
                    return 1;
                case Roles.DRIVER:
                    return 2;
                case Roles.ADMIN:
                    return 3;
                default:
                    return 4;
            }
        }
    }
}
