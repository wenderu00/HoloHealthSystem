using HoloHealthSystem.Domain.Commands.ApointmentCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.CommandsTests.ApointmentCommandTests
{
    [TestClass]
    public class CreateApointmentcommandTests
    {
        private readonly CreateApointmentCommand _invalidCreateApointmentCommand = new CreateApointmentCommand();
        private readonly CreateApointmentCommand _validCreateApointmentCommand = new CreateApointmentCommand("62318902364",Guid.NewGuid(),DateTime.Now);
        public CreateApointmentcommandTests()
        {
            _invalidCreateApointmentCommand.Validate();
            _validCreateApointmentCommand.Validate();
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_false_when_invalid_command_is_given()
        {
            Assert.IsFalse(_invalidCreateApointmentCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_true_when_valid_command_is_given()
        {
            Assert.IsTrue(_validCreateApointmentCommand.IsValid);
        }
    }
}
