namespace MultiValueDictionaryApp.Interfaces
{
    public interface IPrintResultService
    {
        public void PrintItems(HashSet<string> items);

        public void PrintItems(List<string> items);

        public void PrintAllItems(string key, HashSet<string> values, int count);

        public void PrintResult(string result);
    }
}