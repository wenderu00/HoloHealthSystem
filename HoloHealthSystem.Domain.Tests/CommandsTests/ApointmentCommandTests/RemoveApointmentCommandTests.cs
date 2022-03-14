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
    public class RemoveApointmentCommandTests
    {
        private readonly RemoveApointmentCommand _invalidRemoveApointmentCommand = new RemoveApointmentCommand();
        private readonly RemoveApointmentCommand _validRemoveApointmentCommand = new RemoveApointmentCommand(Guid.NewGuid());

        public RemoveApointmentCommandTests()
        {
            _invalidRemoveApointmentCommand.Validate();
            _validRemoveApointmentCommand.Validate();
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_false_when_invalid_remove_apointment_command_is_given()
        {
            Assert.IsFalse(_invalidRemoveApointmentCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_true_when_valid_remove_apointment_command_is_given()
        {
            Assert.IsTrue(_validRemoveApointmentCommand.IsValid);
        }
    }
}
