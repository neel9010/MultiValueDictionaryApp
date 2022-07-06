using Moq;
using MultiValueDictionaryApp.Interfaces;
using Xunit;

namespace MultiValueDictionaryApp.Test
{
    public class CommandTests
    {
        private Mock<ICommandService> _commandService;

        public CommandTests()
        {
            _commandService = new Mock<ICommandService>();
        }

        [Fact]
        public void TestAddMembersAddMember()
        {
            _commandService.Setup(x => x.AddMember("test", "foo"));
            _commandService.Setup(x => x.ContainsMember("test", "test")).Returns(false);

            Assert.Equal(true, _commandService.Object.ContainsMember("test", "test"));
        }
    }
}