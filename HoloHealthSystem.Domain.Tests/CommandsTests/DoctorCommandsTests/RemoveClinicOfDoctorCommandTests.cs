using HoloHealthSystem.Domain.Commands.DoctorCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.CommandsTests.DoctorCommandsTests
{
    [TestClass]
    public class RemoveClinicOfDoctorCommandTests
    {
        private readonly RemoveClinicOfDoctorCommand _invalidRemoveClinicOfDoctorCommand = new RemoveClinicOfDoctorCommand();
        private readonly RemoveClinicOfDoctorCommand _validRemoveClinicOfDoctorCommand = new RemoveClinicOfDoctorCommand(Guid.NewGuid(),Guid.NewGuid());

        public RemoveClinicOfDoctorCommandTests()
        {
            _invalidRemoveClinicOfDoctorCommand.Validate();
            _validRemoveClinicOfDoctorCommand.Validate();
        }

        [TestMethod]
        [TestCategory("commands")]
        public void Should_command_is_valid_is_false_when_invalid_command_is_given()
        {

            Assert.IsFalse(_invalidRemoveClinicOfDoctorCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_command_is_valid_is_true_when_valid_command_is_given()
        {

            Assert.IsTrue(_validRemoveClinicOfDoctorCommand.IsValid);

        }
    }
}
