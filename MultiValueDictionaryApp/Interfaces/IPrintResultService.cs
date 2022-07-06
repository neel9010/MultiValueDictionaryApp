namespace MultiValueDictionaryApp.Interfaces
{
    public interface IPrintResultService
    {
        public void PrintItems(ICollection<string> items);

        public void PrintAllItems(string key, ICollection<string> values, int count);

        public void PrintResult(string result);
    }
}
