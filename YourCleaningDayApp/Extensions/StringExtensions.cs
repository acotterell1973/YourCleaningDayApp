using System.Text.RegularExpressions;

namespace YourCleaningDayApp.Extensions
{
    public static class StringExtensions
    {
        public static string FormatPhoneNumber(this string value)
        {
            return value != null ? $"{double.Parse(value):(###) ###-####}" : "";
        }

        public static string CleanPhoneNumber(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? Regex.Replace(value, @"[^0-9]", "") : null; ;
        }
    }
}
