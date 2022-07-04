namespace MultiValueDictionaryApp.Interfaces
{
    public interface ICommandService
    {
        public HashSet<string> GetAllKeys();

        public HashSet<string> GetAllMembersOfKey(string key);

        public void AddMember(string key, string value);

        public void RemoveMember(string key, string value);

        public void RemoveAllMembers(string key);

        public void Clear();

        public bool ContainsKey(string key);

        public bool ContainsMember(string key, string value);

        public List<string> GetAllMembers();

        public Dictionary<string, HashSet<string>> GetAllItems();
    }
}