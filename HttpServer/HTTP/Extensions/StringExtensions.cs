namespace HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string input)
            => char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }
}
