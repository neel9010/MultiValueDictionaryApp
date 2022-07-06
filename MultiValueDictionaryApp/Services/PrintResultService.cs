using MultiValueDictionaryApp.Interfaces;

namespace MultiValueDictionaryApp.Services
{
    public class PrintResultService : IPrintResultService
    {
        public void PrintAllItems(string key, HashSet<string> values, int count)
        {
            foreach (string value in values)
            {
                count++;
                PrintResult($"{count}) {key}: {value}");
            }
            
             PrintResult("");
        }

        public void PrintItems(HashSet<string> items)
        {
            int count = 0;
            if (items == null || items.Count == 0)
            {
                PrintResult("Not Found!");
            }
            else
            {
                foreach (string item in items)
                {
                    count++;
                    PrintResult($"{count}) {item}");
                }
            }
            
            PrintResult("");
        }

        public void PrintItems(List<string> items)
        {
            int count = 0;
            if (items == null || items.Count == 0)
            {
                PrintResult("Not Found!");
            }
            else
            {
                foreach (string item in items)
                {
                    count++;
                    PrintResult($"{count}) {item}");
                }
            }
            
            PrintResult("");
        }

        public void PrintResult(string message)
        {
            Console.WriteLine(message);
        }
    }
}
