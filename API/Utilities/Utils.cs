using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace API.Utilities
{
    public static class Utils
    {
        public static Dictionary<string, TValue>? ToDictionary<TValue>(object? obj)
        {
            if (obj == null) return null;
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
            return dictionary;
        }

        public static int TrimCompareIgnoreCase(this string a, string b)
        {
            int indexA = 0;
            int indexB = 0;
            while (indexA < a.Length && Char.IsWhiteSpace(a[indexA])) indexA++;
            while (indexB < b.Length && Char.IsWhiteSpace(b[indexB])) indexB++;
            int lenA = a.Length - indexA;
            int lenB = b.Length - indexB;
            while (lenA > 0 && Char.IsWhiteSpace(a[indexA + lenA - 1])) lenA--;
            while (lenB > 0 && Char.IsWhiteSpace(b[indexB + lenB - 1])) lenB--;
            if (lenA == 0 && lenB == 0) return 0;
            if (lenA == 0) return 1;
            if (lenB == 0) return -1;
            int result = String.Compare(a, indexA, b, indexB, Math.Min(lenA, lenB), true);
            if (result == 0)
            {
                if (lenA < lenB) result--;
                if (lenA > lenB) result++;
            }
            return result;
        }

        public static bool TrimContainsIgnoreCase(this string a, string b)
        {
            return Regex.IsMatch(a, Regex.Escape(b.Trim()), RegexOptions.IgnoreCase);
        }
    }
}
