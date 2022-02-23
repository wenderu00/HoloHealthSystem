using HoloHealthSystem.Domain.Commands;
using HoloHealthSystem.Domain.Commands.CityCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.CommandsTests
{
    [TestClass]
    public class CreateClinicCommandTests
    {
        private readonly CreateClinicCommand _invalidCommand = new CreateClinicCommand();
        private readonly CreateClinicCommand _validCommand = new CreateClinicCommand("rua da hora","graças","rua da hora","202",Guid.NewGuid());
        public CreateClinicCommandTests()
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
