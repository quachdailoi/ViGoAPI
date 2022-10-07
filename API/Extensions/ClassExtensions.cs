﻿using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;

namespace API.Extensions
{
    public static class ClassExtensions
    {
        public static TimeOnly ParseExact(this TimeOnly timeOnly, string s)
        {
            return TimeOnly.ParseExact(s, "HH:mm:ss");
        }

        public static DateOnly ParseExact(this DateOnly dateOnly, string s) 
        {
            return DateOnly.ParseExact(s, "dd-MM-yyyy");
        }
        public static string DisplayName(this Enum value)
        {
            var key = $"{value.GetType().FullName}.{value}";

            var name = (DescriptionAttribute[])value
                    .GetType()
                    .GetTypeInfo()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return name.Length > 0 ? name[0].Description : value.ToString();
        }
    }
}
