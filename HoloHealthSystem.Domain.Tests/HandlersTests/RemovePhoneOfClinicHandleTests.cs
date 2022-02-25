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
    public class RemovePhoneOfClinicHandleTests
    {
        private readonly RemovePhoneOfClinicCommand _invalidCommand = new RemovePhoneOfClinicCommand();
        private readonly RemovePhoneOfClinicCommand _validCommand = new RemovePhoneOfClinicCommand("81979001125", Guid.NewGuid());
        private readonly ClinicHandler _handler = new ClinicHandler(new FakeClinicRepository(), new FakeAddressRepository(), new FakeCityRepository(), new FakeManagerRepository());
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
        public void Should_add_phone_when_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.IsTrue(_result.Success);
        }
    }
}
