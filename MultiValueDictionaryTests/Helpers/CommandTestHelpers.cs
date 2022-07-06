using MultiValueDictionaryApp.Services;
using System.Collections.Generic;

namespace MultiValueDictionaryTests.Helpers
{
    public static class CommandTestHelpers
    {
        public static CommandService AddTestData(this CommandService commandService)
        {
            commandService.AddMember("foo", "bar");
            commandService.AddMember("foo", "baz");
            commandService.AddMember("bang", "bar");
            commandService.AddMember("bang", "baz");
            commandService.AddMember("bang", "data");

            return commandService;
        }

        public static HashSet<string> Keys()
        {
            return new HashSet<string>()
            {
                "foo", "bang"
            };
        }

        public static List<string> Members()
        {
            return new List<string>()
            {
                "bar", "baz", "bar", "baz", "data"
            };
        }

        public static int KeysCount { get { return 2; } }

        public static int MembersCount { get { return 5; } }

        public static Dictionary<string, HashSet<string>> GetAllTestItems()
        {
            return new Dictionary<string, HashSet<string>>
            {
                { "foo", new HashSet<string> { "bar", "baz" } },
                { "bang", new HashSet<string> {"bar", "baz", "data"} },
            };
        }
    }
}