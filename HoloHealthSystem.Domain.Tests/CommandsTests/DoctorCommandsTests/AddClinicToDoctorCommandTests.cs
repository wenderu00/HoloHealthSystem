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
    public class AddClinicToDoctorCommandTests
    {
        private readonly AddClinicToDoctorCommand _invalidAddClinicToDoctorCommand = new AddClinicToDoctorCommand();
        private readonly AddClinicToDoctorCommand _validAddClinicToDoctorCommand = new AddClinicToDoctorCommand(Guid.NewGuid(),"12345678");

        public AddClinicToDoctorCommandTests()
        {
            _invalidAddClinicToDoctorCommand.Validate();
            _validAddClinicToDoctorCommand.Validate();
        }
        [TestMethod]
        [TestCategory("commands")]
        public void Should_command_is_valid_is_false_when_invalid_command_is_given()
        {
            
            Assert.IsFalse(_invalidAddClinicToDoctorCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_command_is_valid_is_true_when_valid_command_is_given()
        {

            Assert.IsTrue(_validAddClinicToDoctorCommand.IsValid);

        }
    }
}
