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
    public class MarkAsDoneApointmentCommandTests
    {
        private readonly MarkAsDoneApointmentCommand _invalidmarkAsDoneApointmentCommand = new MarkAsDoneApointmentCommand();
        private readonly MarkAsDoneApointmentCommand _validmarkAsDoneApointmentCommand = new MarkAsDoneApointmentCommand(Guid.NewGuid());

        public MarkAsDoneApointmentCommandTests()
        {
            _invalidmarkAsDoneApointmentCommand.Validate();
            _validmarkAsDoneApointmentCommand.Validate();
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_false_when_invalid_mark_as_done_command_is_given()
        {
            Assert.IsFalse(_invalidmarkAsDoneApointmentCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_true_when_valid_mark_as_done_command_is_given()
        {
            Assert.IsTrue(_validmarkAsDoneApointmentCommand.IsValid);
        }
    }
}
