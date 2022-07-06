namespace MultiValueDictionaryApp.Helpers
{
    public static class Commands
    {
        public const string KEYS = "KEYS";
        public const string ADD = "ADD";
        public const string REMOVE = "REMOVE";
        public const string REMOVE_ALL = "REMOVEALL";
        public const string CLEAR = "CLEAR";
        public const string KEY_EXISTS = "KEYEXISTS";
        public const string MEMBERS = "MEMBERS";
        public const string MEMBER_EXISTS = "MEMBEREXISTS";
        public const string ALL_MEMBERS = "ALLMEMBERS";
        public const string ITEMS = "ITEMS";
        public const string QUIT = "QUIT";
        public const string LIST_COMMANDS = "LISTCOMMANDS";
        public static HashSet<string> AVAILABLE_COMMANDS = GetAvailableCommands();

        private static HashSet<string> GetAvailableCommands()
        {
            return new HashSet<string> {
               KEYS, ADD, REMOVE, REMOVE_ALL, CLEAR,KEY_EXISTS,
                MEMBERS, MEMBER_EXISTS,ALL_MEMBERS, ITEMS, QUIT, LIST_COMMANDS
            };
        }
    }
}