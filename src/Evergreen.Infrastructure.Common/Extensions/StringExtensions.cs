namespace Evergreen.Infrastructure.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsEmpty(this string s)
        {
            return s == string.Empty;
        }
    }
}