using MultiValueDictionaryApp.Helpers;
using MultiValueDictionaryApp.Interfaces;

namespace MultiValueDictionaryApp.Services
{
    public class MessageService : IMessageService
    {
        public void Added_Message()
        {
            DisplayMessage(ActionMessages.ADDED);
        }

        public void KeyNotExists_Message()
        {
            DisplayMessage(ActionMessages.KEY_DOES_NOT_EXIST);
        }

        public void MemberExists_Message()
        {
            DisplayMessage(ActionMessages.MEMBER_EXISTS_FOR_KEY);
        }

        public void MemberNotExists_Message()
        {
            DisplayMessage(ActionMessages.MEMBER_DOES_NOT_EXIST);
        }

        public void Removed_Message()
        {
            DisplayMessage(ActionMessages.REMOVED);
        }

        public void EmptySet_Message()
        {
            DisplayMessage(ActionMessages.EMPTY);
        }

        public void EnterCommand_Message()
        {
            Console.Write(ActionMessages.ENTER_COMMAND);
        }

        public void InvalidCommand_Message()
        {
            DisplayMessage(ActionMessages.INVALID_COMMAND);
        }

        public void Cleared_Message()
        {
            DisplayMessage(ActionMessages.CLEARED);
        }

        public void AppInfo_Message()
        {
            DisplayMessage(AppMessages.APP_INFO);
            DisplayMessage("");
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}