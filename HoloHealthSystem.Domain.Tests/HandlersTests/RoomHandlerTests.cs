using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.RoomCommands;
using HoloHealthSystem.Domain.Handlers;
using HoloHealthSystem.Domain.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.HandlersTests
{
    [TestClass]
    public class RoomHandlerTests
    {
        private readonly CreateRoomCommand _invalidCreateRoomCommand = new CreateRoomCommand();
        private readonly CreateRoomCommand _validCreateRoomCommand = new CreateRoomCommand(Guid.NewGuid(), "202");
        private readonly UpdateRoomNumberCommand _invalidUpdateRoomNumberCommand = new UpdateRoomNumberCommand();
        private readonly UpdateRoomNumberCommand _validUpdateRoomNumberCommand = new UpdateRoomNumberCommand(Guid.NewGuid(), "203");
        private readonly RoomHandler _handler = new RoomHandler(new FakeClinicRepository(),new FakeRoomRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_create_room_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCreateRoomCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_create_room_when_create_room_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCreateRoomCommand);
            Assert.IsTrue(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_update_room_number_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidUpdateRoomNumberCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_update_room_number_when_update_room_number_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validUpdateRoomNumberCommand);
            Assert.IsTrue(_result.Success);
        }

    }
}
