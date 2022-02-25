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
    public class CreateDoctorCommandTests
    {
        private readonly CreateDoctorCommand _invalidCreateDoctorCommand = new CreateDoctorCommand();
        private readonly CreateDoctorCommand _validCreateDoctorCommand = new CreateDoctorCommand("12345678",0,"mwmcjr@gmail.com","márcio","wendell",DateTime.Now,"62318902364");

        public CreateDoctorCommandTests()
        {
            _invalidCreateDoctorCommand.Validate();
            _validCreateDoctorCommand.Validate();
        }
        [TestMethod]
        [TestCategory("commands")]
        public void Should_command_is_valid_is_false_when_invalid_command_is_given()
        {

            Assert.IsFalse(_invalidCreateDoctorCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_command_is_valid_is_true_when_valid_command_is_given()
        {

            Assert.IsTrue(_validCreateDoctorCommand.IsValid);

        }
    }
}
