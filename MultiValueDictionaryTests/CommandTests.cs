using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiValueDictionaryApp.Services;
using MultiValueDictionaryTests.Helpers;
using System.Collections.Generic;

namespace MultiValueDictionaryTests
{
    [TestClass]
    public class CommandTests
    {
        private readonly CommandService _commandService;

        public CommandTests()
        {
            _commandService = new CommandService();
        }

        [TestMethod]
        public void TestAddCommand_AddsMember()
        {
            _commandService.AddTestData();
            var result = _commandService.ContainsMember("bang", "bar");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestKeysCommand_ReturnsAllKeys()
        {
            _commandService.AddTestData();
            HashSet<string>? result = _commandService.GetAllKeys();
            HashSet<string> expectedResults = CommandTestHelpers.Keys();

            Assert.IsTrue(expectedResults.SetEquals(result));
        }

        [TestMethod]
        public void TestKeysCommand_ReturnsNoKeys()
        {
            HashSet<string>? result = _commandService.GetAllKeys();
            HashSet<string> expectedResults = CommandTestHelpers.Keys();

            Assert.IsFalse(expectedResults.SetEquals(result));
        }

        [TestMethod]
        public void TestAllMembersCommand_ReturnsAllMembers()
        {
            _commandService.AddTestData();
            List<string>? result = _commandService.GetAllMembers();
            List<string> expectedResults = CommandTestHelpers.Members();

            CollectionAssert.AreEqual(result, expectedResults);
        }

        [TestMethod]
        public void TestAllMembersCommand_ReturnsNoMembers()
        {
            List<string>? result = _commandService.GetAllMembers();
            List<string> expectedResults = CommandTestHelpers.Members();

            CollectionAssert.AreNotEqual(result, expectedResults);
        }

        [TestMethod]
        public void TestRemoveCommand_RemovesMember()
        {
            _commandService.AddTestData();
            _commandService.RemoveMember("bang", "bar");
            List<string>? result = _commandService.GetAllMembers();
            List<string> expectedResults = CommandTestHelpers.Members();

            CollectionAssert.AreNotEqual(result, expectedResults);
        }

        [TestMethod]
        public void TestRemoveAllCommand_RemovesAllMembers()
        {
            _commandService.AddTestData();
            _commandService.RemoveAllMembers("bang");
            List<string>? result = _commandService.GetAllMembers();
            List<string> expectedResults = CommandTestHelpers.Members();

            CollectionAssert.AreNotEqual(result, expectedResults);
        }

        [TestMethod]
        public void TestClearCommand_ClearsKeysAndMembers()
        {
            _commandService.AddTestData();

            HashSet<string>? allKeys = _commandService.GetAllKeys();
            List<string>? allMembers = _commandService.GetAllMembers();
            Assert.AreEqual(CommandTestHelpers.KeysCount, allKeys.Count);
            Assert.AreEqual(CommandTestHelpers.MembersCount, allMembers.Count);

            _commandService.Clear();

            allKeys = _commandService.GetAllKeys();
            allMembers = _commandService.GetAllMembers();
            Assert.AreNotEqual(CommandTestHelpers.KeysCount, allKeys.Count);
            Assert.AreNotEqual(CommandTestHelpers.MembersCount, allMembers.Count);
        }

        [TestMethod]
        public void TestKeyExistsCommand_ChecksExistingKey()
        {
            _commandService.AddTestData();
            Assert.IsTrue(_commandService.ContainsKey("foo"));
        }

        [TestMethod]
        public void TestKeyExistsCommand_ChecksExistingKeyFail()
        {
            _commandService.AddTestData();
            Assert.IsFalse(_commandService.ContainsKey("food"));
        }

        [TestMethod]
        public void TestMemberExistsCommand_ChecksExistingMember()
        {
            _commandService.AddTestData();
            Assert.IsTrue(_commandService.ContainsMember("foo", "bar"));
        }

        [TestMethod]
        public void TestMemberExistsCommand_ChecksExistingMemberFail()
        {
            _commandService.AddTestData();
            Assert.IsFalse(_commandService.ContainsMember("food", "bar"));
        }

        [TestMethod]
        public void TestMembersCommand_ChecksExistingMembersForKey()
        {
            _commandService.AddTestData();
            HashSet<string> expectedMembers = new HashSet<string>() { "bar", "baz" };
            HashSet<string>? members = _commandService.GetAllMembersOfKey("foo");

            Assert.AreEqual(2, members.Count);
            Assert.IsTrue(expectedMembers.SetEquals(members));
        }

        [TestMethod]
        public void TestMembersCommand_ChecksExistingMembersForKeyFail()
        {
            _commandService.AddTestData();
            HashSet<string>? members = _commandService.GetAllMembersOfKey("food");

            Assert.IsNull(members);
        }

        [TestMethod]
        public void TestItemsCommand_ReturnsAllKeysAndItsMembers()
        {
            _commandService.AddTestData();

            Dictionary<string, HashSet<string>>? result = _commandService.GetAllItems();
            var expectedItems = CommandTestHelpers.GetAllTestItems();

            Assert.AreEqual(expectedItems.Count, result.Count);

            foreach (var item in expectedItems)
            {
                Assert.IsTrue(item.Value.SetEquals(result[item.Key]));
            }
        }
    }
}