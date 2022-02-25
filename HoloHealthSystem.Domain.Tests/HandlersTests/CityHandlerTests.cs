using HoloHealthSystem.Domain.Commands.CityCommands;
using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.Handlers;
using HoloHealthSystem.Domain.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.HandlersTests
{
    [TestClass]
    public class CreateCityHandlersTests
    {
        private readonly CreateCityCommand _invalidCommand = new CreateCityCommand();
        private readonly CreateCityCommand _validCommand = new CreateCityCommand(Guid.NewGuid(), "Recife");
        private readonly CityHandler _handler = new CityHandler(new FakeStateRepository(),new FakeCityRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_create_city_when_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.IsTrue(_result.Success);
        }

    }
}
