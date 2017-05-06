namespace YourCleaningDayApp.Extensions
{
    public static class StringExtensions
    {
        public static string FormatWith(this string value, string args)
        {
            return $"{double.Parse(value):(###) ###-####}";
        }
    }
}
