using MultiValueDictionaryApp.Helpers;
using MultiValueDictionaryApp.Interfaces;

namespace MultiValueDictionaryApp.Services
{
    public class MessageService : IMessageService
    {
        public void Added_Message()
        {
            Console.WriteLine(ActionMessages.ADDED);
        }

        public void KeyNotExists_Message()
        {
            Console.WriteLine(ActionMessages.KEY_DOES_NOT_EXIST);
        }

        public void MemberExists_Message()
        {
            Console.WriteLine(ActionMessages.MEMBER_EXISTS_FOR_KEY);
        }

        public void MemberNotExists_Message()
        {
            Console.WriteLine(ActionMessages.MEMBER_DOES_NOT_EXIST);
        }

        public void Removed_Message()
        {
            Console.WriteLine(ActionMessages.REMOVED);
        }

        public void EmptySet_Message()
        {
            Console.WriteLine(ActionMessages.EMPTY);
        }

        public void EnterCommand_Message()
        {
            Console.Write(ActionMessages.ENTER_COMMAND);
        }

        public void InvalidCommand_Message()
        {
            Console.WriteLine(ActionMessages.INVALID_COMMAND);
        }

        public void Cleared_Message()
        {
            Console.WriteLine(ActionMessages.CLEARED);
        }
    }
}