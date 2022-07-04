using MultiValueDictionaryApp.Helpers;
using MultiValueDictionaryApp.Interfaces;

namespace MultiValueDictionaryApp
{
    public class App
    {
        private readonly ICommandService _commandService;
        private readonly IMessageService _messageService;
        private readonly IPrintResultService _printResultService;

        public App(ICommandService commandService, IMessageService messageService, IPrintResultService printResultService)
        {
            _commandService = commandService;
            _messageService = messageService;
            _printResultService = printResultService;
        }

        public void Run()
        {
            while (true)
            {
                _messageService.EnterCommand_Message();

                string command = Console.ReadLine();

                // Invalid Command
                if (string.IsNullOrEmpty(command))
                {
                    _messageService.InvalidCommand_Message();
                    continue;
                }

                // Get commands from user input
                string[] commands = command.Split(' ');
                string action = commands[0].ToUpper();

                string[] args = Array.Empty<string>();
                if (command.Length > 1)
                {
                    args = commands.Skip(1).ToArray().FormatArgs();
                }

                //Add Members
                if (action == Commands.ADD && args.Length == 2)
                {
                    string key = args[0];
                    string value = args[1];

                    // check if member is already exists for give key
                    if (_commandService.ContainsMember(key, value))
                    {
                        _messageService.MemberExists_Message();
                    }
                    else
                    {
                        _commandService.AddMember(key, value);
                        _messageService.Added_Message();
                    }
                }
                //Print All Keys
                else if (action == Commands.KEYS && args.Length == 0)
                {
                    HashSet<string> keys = _commandService.GetAllKeys();

                    if (keys != null && keys.Count > 0)
                    {
                        _printResultService.PrintItems(keys);
                    }
                    else
                    {
                        _messageService.EmptySet_Message();
                    }
                }
                // Get Members
                else if (action == Commands.MEMBERS && args.Length == 1)
                {
                    var members = _commandService.GetAllMembersOfKey(args[0]);
                    if (members != null)
                    {
                        _printResultService.PrintItems(members);
                    }
                    else
                    {
                        _messageService.KeyNotExists_Message();
                    }
                }
                // Remove Member
                else if (action == Commands.REMOVE && args.Length == 2)
                {
                    string key = args[0];
                    string value = args[1];

                    if (!_commandService.ContainsKey(key))
                    {
                        _messageService.KeyNotExists_Message();
                    }
                    else if (!_commandService.ContainsMember(key, value))
                    {
                        _messageService.MemberNotExists_Message();
                    }
                    else
                    {
                        _commandService.RemoveMember(key, value);
                        _messageService.Removed_Message();
                    }
                }
                // Remove All Members
                else if (action == Commands.REMOVE_ALL && args.Length == 1)
                {
                    string key = args[0];

                    if (!_commandService.ContainsKey(key))
                    {
                        _messageService.KeyNotExists_Message();
                    }
                    else
                    {
                        _commandService.RemoveAllMembers(args[0]);
                        _messageService.Removed_Message();
                    }
                }
                // Clear Everything
                else if (action == Commands.CLEAR && args.Length == 0)
                {
                    _commandService.Clear();
                    _messageService.Cleared_Message();
                }
                // Key Exists
                else if (action == Commands.KEY_EXISTS && args.Length == 1)
                {
                    bool result = _commandService.ContainsKey(args[0]);
                    _printResultService.PrintResult(result.ToString().ToLower());
                }
                // Member Exists
                else if (action == Commands.MEMBER_EXISTS && args.Length == 2)
                {
                    string key = args[0];
                    string value = args[1];

                    bool result = _commandService.ContainsMember(key, value);
                    _printResultService.PrintResult(result.ToString().ToLower());
                }
                // All members
                else if (action == Commands.ALL_MEMBERS && args.Length == 0)
                {
                    List<string>? members = _commandService.GetAllMembers();
                    if (members == null || members.Count == 0)
                    {
                        _messageService.EmptySet_Message();
                    }
                    else
                    {
                        _printResultService.PrintItems(members);
                    }
                }
                // All Items
                else if (action == Commands.ITEMS && args.Length == 0)
                {
                    Dictionary<string, HashSet<string>>? allItems = _commandService.GetAllItems();

                    if (allItems == null || allItems.Count == 0)
                    {
                        _messageService.EmptySet_Message();
                    }
                    else
                    {
                        int count = 0;
                        foreach (var item in allItems)
                        {
                            string? key = item.Key;
                            HashSet<string>? values = item.Value;
                            _printResultService.PrintAllItems(key, values, count);
                            count = item.Value.Count;
                        }
                    }
                }
                // Invalid Command
                else
                {
                    _messageService.InvalidCommand_Message();
                    continue;
                }
            }
        }
    }
}