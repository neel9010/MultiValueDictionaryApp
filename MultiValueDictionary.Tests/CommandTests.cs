using Moq;
using MultiValueDictionaryApp.Interfaces;
using Xunit;

namespace MultiValueDictionary.Tests
{
    public class CommandTests
    {
        private Mock<ICommandService> _commandService;
        public CommandTests()
        {
            _commandService = new Mock<ICommandService>();
        }

        [Fact]
        public void TestAddMember()
        {
            _commandService.Setup(x => x.AddMember("foo", "bar"));
            _commandService.Setup(x => x.AddMember("foo", "baz"));
            _commandService.Setup(x => x.AddMember("call", "bar"));

            _commandService.Setup(x => x.ContainsMember("foo", "bar")).Returns(true);
            _commandService.Setup(x => x.ContainsMember("call", "bad")).Returns(false);

            Assert.True(_commandService.Object.ContainsMember("foo", "bar"));
            Assert.False(_commandService.Object.ContainsMember("call", "bad"));
        }
    }
}