using MultiValueDictionaryApp.Interfaces;

namespace MultiValueDictionaryApp.Services
{
    public class CommandService : ICommandService
    {
        private Dictionary<string, HashSet<string>> _dictionary = new Dictionary<string, HashSet<string>>();

        public void AddMember(string key, string value)
        {
            if (_dictionary.ContainsKey(key))
            {
                _dictionary[key].Add(value);
            }
            else
            {
                _dictionary.Add(key, new HashSet<string>()
                {
                    value
                });
            }
        }

        public void Clear()
        {
            if (_dictionary.Any())
            {
                _dictionary.Clear();
            }
        }

        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool ContainsMember(string key, string value)
        {
            HashSet<string> values = _dictionary.GetValueOrDefault(key);

            if (values != null)
            {
                return values.Contains(value);
            }

            return false;
        }

        public Dictionary<string, HashSet<string>> GetAllItems()
        {
            return _dictionary;
        }

        public HashSet<string> GetAllKeys()
        {
            HashSet<string> keys = new HashSet<string>();

            foreach (string key in _dictionary.Keys)
            {
                keys.Add(key);
            }

            return keys;
        }

        public List<string> GetAllMembers()
        {
            List<string>? members = new List<string>();

            if (_dictionary.Any())
            {
                foreach (string key in _dictionary.Keys)
                {
                    members.AddRange(_dictionary[key]);
                }
            }

            return members;
        }

        public HashSet<string> GetAllMembersOfKey(string key)
        {
            HashSet<string> members = new HashSet<string>();
            members = _dictionary.GetValueOrDefault(key);
            return members;
        }

        public void RemoveAllMembers(string key)
        {
            _dictionary.Remove(key);
        }

        public void RemoveMember(string key, string value)
        {
            var members = GetAllMembersOfKey(key);
            members.Remove(value);

            if (members.Count == 0)
            {
                _dictionary.Remove(key);
            }
        }
    }
}