using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.StateCommands;
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
    public class CreateStateHandlerTests
    {
        private readonly CreateStateCommand _invalidCommand = new CreateStateCommand();
        private readonly CreateStateCommand _validCommand = new CreateStateCommand("Pernambuco");
        private readonly StateHandler _handler = new StateHandler(new FakeStateRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_create_new_state_when_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.IsTrue(_result.Success);
        }

    }
}
