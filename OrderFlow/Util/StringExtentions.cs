namespace OrderFlow.Util
{
    public static class StringExtentions
    {
        public static string TrimStart(this string target, string trimChars)
        {
            return target.TrimStart(trimChars.ToCharArray());
        }
    }
}
