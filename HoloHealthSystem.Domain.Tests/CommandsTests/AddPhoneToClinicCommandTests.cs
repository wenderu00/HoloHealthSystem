using HoloHealthSystem.Domain.Commands.ClinicCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.CommandsTests
{
    [TestClass]
    public class AddPhoneToClinicCommandTests 
    {
        private readonly AddPhoneToClinicCommand _invalidCommand = new AddPhoneToClinicCommand();
        private readonly AddPhoneToClinicCommand _validCommand = new AddPhoneToClinicCommand("81979001125", Guid.NewGuid());
        public AddPhoneToClinicCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_command_is_valid_is_false_when_invalid_command_is_given()
        {

            Assert.IsFalse(_invalidCommand.IsValid);

        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_command_is_valid_is_true_when_valid_command_is_given()
        {

            Assert.IsTrue(_validCommand.IsValid);

        }
    }
}
