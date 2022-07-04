namespace MultiValueDictionaryApp.Helpers
{
    public static class Formatting
    {
        public static string[] FormatArgs(this string[] args)
        {
            Array.ForEach(args, x => x.Trim().ToLower());
            return args;
        }
    }
}