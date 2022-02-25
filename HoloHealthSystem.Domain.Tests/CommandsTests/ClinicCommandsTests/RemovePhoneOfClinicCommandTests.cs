using HoloHealthSystem.Domain.Commands.ClinicCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.CommandsTests.ClinicCommandsTests
{
    [TestClass]
    public class RemovePhoneOfClinicCommandTests
    {
        private readonly RemovePhoneOfClinicCommand _invalidCommand = new RemovePhoneOfClinicCommand();
        private readonly RemovePhoneOfClinicCommand _validCommand = new RemovePhoneOfClinicCommand("81979001125", Guid.NewGuid());
        public RemovePhoneOfClinicCommandTests()
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
