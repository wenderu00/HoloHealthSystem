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
    public class CreateRoomCommandTests
    {
        private readonly CreateRoomCommand _invalidCreateRoomCommand = new CreateRoomCommand();
        private readonly CreateRoomCommand _validCreateRoomCommand = new CreateRoomCommand(Guid.NewGuid(), "202");
        public CreateRoomCommandTests()
        {
            _invalidCreateRoomCommand.Validate();
            _validCreateRoomCommand.Validate(); 
        }

        [TestMethod]
        [TestCategory("commands")]
        public void Should_command_is_valid_is_false_when_invalid_command_is_given()
        {

            Assert.IsFalse(_invalidCreateRoomCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_command_is_valid_is_true_when_valid_command_is_given()
        {

            Assert.IsTrue(_validCreateRoomCommand.IsValid);

        }

    }
}
