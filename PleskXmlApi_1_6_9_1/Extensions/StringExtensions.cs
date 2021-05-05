namespace PleskXmlApi_1_6_9_1.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string input)
        {
            return input == null || input.Trim().Length <= 0;
        }

        public static bool IsNotNullOrWhiteSpace(this string input)
        {
            return !input.IsNullOrWhiteSpace();
        }
    }
}
