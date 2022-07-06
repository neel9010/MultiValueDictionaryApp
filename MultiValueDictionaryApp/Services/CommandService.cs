using MultiValueDictionaryApp.Interfaces;

namespace MultiValueDictionaryApp.Services
{
    public class CommandService : ICommandService
    {
        private readonly Dictionary<string, HashSet<string>> _dictionary;

        public CommandService()
        {
            _dictionary = new Dictionary<string, HashSet<string>>();
        }

        /// <summary>
        /// Adds Member for given key in dictionary
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">value</param>
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

        /// <summary>
        /// Clears all keys and members from the dictionary
        /// </summary>
        public void Clear()
        {
            if (_dictionary.Any())
            {
                _dictionary.Clear();
            }
        }

        /// <summary>
        /// Checks if the provided key exists in the dictionary
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Checks if the member exisits for given key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public bool ContainsMember(string key, string value)
        {
            HashSet<string>? values = _dictionary.GetValueOrDefault(key);

            if (values != null)
            {
                return values.Contains(value);
            }

            return false;
        }

        /// <summary>
        /// Returns all the keys and its members from dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, HashSet<string>> GetAllItems()
        {
            return _dictionary;
        }

        /// <summary>
        /// Returns all keys from dictionary
        /// </summary>
        /// <returns></returns>
        public HashSet<string> GetAllKeys()
        {
            HashSet<string> keys = new();

            foreach (string key in _dictionary.Keys)
            {
                keys.Add(key);
            }

            return keys;
        }

        /// <summary>
        /// Returns all members from the dictionary
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllMembers()
        {
            List<string>? members = new();

            if (_dictionary.Any())
            {
                foreach (string key in _dictionary.Keys)
                {
                    members.AddRange(_dictionary[key]);
                }
            }

            return members;
        }

        /// <summary>
        /// Returns all memebrs for the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public HashSet<string>? GetAllMembersOfKey(string key)
        {
            return _dictionary.GetValueOrDefault(key);
        }

        /// <summary>
        /// Removes all the members for the given key
        /// </summary>
        /// <param name="key"></param>
        public void RemoveAllMembers(string key)
        {
            _dictionary.Remove(key);
        }

        /// <summary>
        /// Removes given member for the given key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void RemoveMember(string key, string value)
        {
            var members = GetAllMembersOfKey(key);

            if (members != null)
            {
                members.Remove(value);

                if (members.Count == 0)
                {
                    _dictionary.Remove(key);
                }
            }
        }
    }
}