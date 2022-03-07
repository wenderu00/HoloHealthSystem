using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.PacientCommands;
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
    public class PacienteHandlerTests
    {
        private readonly CreatePacientCommand _invalidCreatePacientCommand = new CreatePacientCommand();
        private readonly CreatePacientCommand _validCreatePacientCommand = new CreatePacientCommand("mwmcjr@gmail.com", "márcio", "wendell", DateTime.Now, "62318902364");
        private readonly PacientHandler _handler = new PacientHandler(new FakePacientRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_invalid_comand_is_given()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCreatePacientCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_create_pacient_when_valid_comand_is_given()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCreatePacientCommand);
            Assert.IsTrue(_result.Success);
        }
    }
}
