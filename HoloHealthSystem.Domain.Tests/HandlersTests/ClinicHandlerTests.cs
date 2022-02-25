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
    public class ClinicHandlerTests
    {
        private readonly CreateClinicCommand _invalidCreateClinicCommand = new CreateClinicCommand();
        private readonly CreateClinicCommand _validCreateClinicCommand = new CreateClinicCommand("rua da hora", "graças", "rua da hora", "202", Guid.NewGuid());
        private readonly AddManagerToClinicCommand _invalidAddManagerToClinicCommand = new AddManagerToClinicCommand();
        private readonly AddManagerToClinicCommand _validAddManagerToClinicCommand = new AddManagerToClinicCommand(Guid.NewGuid(), Guid.NewGuid());
        private readonly AddPhoneToClinicCommand _invalidAddPhoneToClinicCommand = new AddPhoneToClinicCommand();
        private readonly AddPhoneToClinicCommand _validAddPhoneToClinicCommand = new AddPhoneToClinicCommand("81979001125", Guid.NewGuid());
        private readonly RemoveManagerOfClinicCommand _invalidRemoveManagerOfClinicCommand = new RemoveManagerOfClinicCommand();
        private readonly RemoveManagerOfClinicCommand _validRemoveManagerOfClinicCommand = new RemoveManagerOfClinicCommand(Guid.NewGuid(), Guid.NewGuid());
        private readonly RemovePhoneOfClinicCommand _invalidRemovePhoneOfClinicCommand = new RemovePhoneOfClinicCommand();
        private readonly RemovePhoneOfClinicCommand _validRemovePhoneOfClinicCommand = new RemovePhoneOfClinicCommand("81979001125", Guid.NewGuid());
        private readonly ClinicHandler _handler = new ClinicHandler(new FakeClinicRepository(), new FakeAddressRepository(), new FakeCityRepository(), new FakeManagerRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_create_clinic_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCreateClinicCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_create_clinic_when_create_clinic_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCreateClinicCommand);
            Assert.IsTrue(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_add_manager_to_clinic_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidAddManagerToClinicCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_add_manager_to_clinic_when_add_manager_to_clinic_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validAddManagerToClinicCommand);
            Assert.IsTrue(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_add_phone_to_clinic_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidAddPhoneToClinicCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_add_phone_to_clinic_when_add_phone_to_clinic_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validAddPhoneToClinicCommand);
            Assert.IsTrue(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_remove_manager_of_clinic_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidRemoveManagerOfClinicCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_remove_manager_of_clinic_when_remove_manager_of_clinic_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validRemoveManagerOfClinicCommand);
            Assert.IsTrue(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_remove_phone_of_clinic_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidRemovePhoneOfClinicCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_remove_fone_of_clinic_when_remove_phone_of_clinic_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validRemovePhoneOfClinicCommand);
            Assert.IsTrue(_result.Success);
        }
    }
}
