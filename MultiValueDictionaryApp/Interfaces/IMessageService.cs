namespace MultiValueDictionaryApp.Interfaces
{
    public interface IMessageService
    {
        public void Added_Message();

        public void Removed_Message();

        public void EmptySet_Message();

        public void KeyNotExists_Message();

        public void MemberNotExists_Message();

        public void MemberExists_Message();

        public void EnterCommand_Message();

        public void InvalidCommand_Message();

        public void Cleared_Message();
    }
}