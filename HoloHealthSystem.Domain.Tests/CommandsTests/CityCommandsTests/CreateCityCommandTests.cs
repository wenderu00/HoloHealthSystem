using HoloHealthSystem.Domain.Commands.CityCommands;
using HoloHealthSystem.Domain.Commands.StateCommands;
using HoloHealthSystem.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.CommandsTests.CityCommandsTests
{
    [TestClass]
    public class CreateCityCommandTests
    {
        private readonly CreateCityCommand _invalidCommand = new CreateCityCommand();
        private readonly CreateCityCommand _validCommand = new CreateCityCommand(Guid.NewGuid(),"Recife");
        public CreateCityCommandTests()
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
