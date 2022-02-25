using HoloHealthSystem.Domain.Commands.RoomCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.CommandsTests.RoomCommandsTests
{
    [TestClass]
    public class UpdateRoomNumberCommandTests
    {
        private readonly UpdateRoomNumberCommand _invalidUpdateRoomNumberCommand = new UpdateRoomNumberCommand();
        private readonly UpdateRoomNumberCommand _validUpdateRoomNumberCommand = new UpdateRoomNumberCommand(Guid.NewGuid(), "203");

        public UpdateRoomNumberCommandTests()
        {
            _invalidUpdateRoomNumberCommand.Validate();
            _validUpdateRoomNumberCommand.Validate();
        }
        [TestMethod]
        [TestCategory("commands")]
        public void Should_command_is_valid_is_false_when_invalid_command_is_given()
        {

            Assert.IsFalse(_invalidUpdateRoomNumberCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_command_is_valid_is_true_when_valid_command_is_given()
        {

            Assert.IsTrue(_validUpdateRoomNumberCommand.IsValid);

        }
    }
}
