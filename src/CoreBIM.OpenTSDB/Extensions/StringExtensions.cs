using System;
namespace OpenTSDB.Core.Extensions
{
    public static partial class StringExtensions
    {
        public static string EnsureEndsWith(this string str, char c)
        {
            return str.EnsureEndsWith(c, StringComparison.Ordinal);
        }
        public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            if (str.EndsWith(c.ToString(), comparisonType))
            {
                return str;
            }
            return str + c.ToString();
        }


    }
}