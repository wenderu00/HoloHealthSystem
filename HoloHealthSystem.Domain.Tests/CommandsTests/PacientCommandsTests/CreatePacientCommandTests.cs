using HoloHealthSystem.Domain.Commands.PacientCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.CommandsTests.PacientCommandsTests
{
    [TestClass]
    public class CreatePacientCommandTests
    {
        private readonly CreatePacientCommand _invalidCreatePacientCommand = new CreatePacientCommand();
        private readonly CreatePacientCommand _validCreatePacientCommand = new CreatePacientCommand("mwmcjr@gmail.com", "márcio", "wendell", DateTime.Now, "62318902364");

        public CreatePacientCommandTests()
        {
            _invalidCreatePacientCommand.Validate();
            _validCreatePacientCommand.Validate();
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_false_when_invalid_command_is_given()
        {
            bool result = _invalidCreatePacientCommand.IsValid;
            Assert.IsFalse(result);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_true_when_valid_command_is_given()
        {
            bool result = _validCreatePacientCommand.IsValid;
            Assert.IsTrue(result);
        }

    }
}
