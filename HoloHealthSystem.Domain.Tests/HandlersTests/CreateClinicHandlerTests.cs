using HoloHealthSystem.Domain.Commands.ClinicCommands;
using HoloHealthSystem.Domain.Commands.Contracts;
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
    public class CreateClinicHandlerTests
    {
        private readonly CreateClinicCommand _invalidCommand = new CreateClinicCommand();
        private readonly CreateClinicCommand _validCommand = new CreateClinicCommand("rua da hora", "graças", "rua da hora", "202", Guid.NewGuid());
        private readonly ClinicHandler _handler = new ClinicHandler(new FakeClinicRepository(), new FakeAddressRepository(), new FakeCityRepository());
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
        public void Should_create_clinic_when_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.IsTrue(_result.Success);
        }
    }
}
