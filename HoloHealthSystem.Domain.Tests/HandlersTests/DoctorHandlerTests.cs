using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.DoctorCommands;
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
    public class DoctorHandlerTests
    {
        private readonly CreateDoctorCommand _invalidCreateDoctorCommand = new CreateDoctorCommand();
        private readonly CreateDoctorCommand _validCreateDoctorCommand = new CreateDoctorCommand("12345678", 0, "mwmcjr@gmail.com", "márcio", "wendell", DateTime.Now, "62318902364");
        private readonly AddClinicToDoctorCommand _invalidAddClinicToDoctorCommand = new AddClinicToDoctorCommand();
        private readonly AddClinicToDoctorCommand _validAddClinicToDoctorCommand = new AddClinicToDoctorCommand(Guid.NewGuid(), "12345678");
        private readonly RemoveClinicOfDoctorCommand _invalidRemoveClinicOfDoctorCommand = new RemoveClinicOfDoctorCommand();
        private readonly RemoveClinicOfDoctorCommand _validRemoveClinicOfDoctorCommand = new RemoveClinicOfDoctorCommand(Guid.NewGuid(), "12345678");
        private readonly DoctorHandler _handler = new DoctorHandler(new FakeDoctorRepository(), new FakeClinicRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        [TestMethod]
        [TestCategory("Handler")]
        public void Should_stop_execution_when_create_doctor_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCreateDoctorCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handler")]
        public void Should_create_doctor_when_create_doctor_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCreateDoctorCommand);
            Assert.IsTrue(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handler")]
        public void Should_stop_execution_when_add_clinic_to_doctor_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidAddClinicToDoctorCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handler")]
        public void Should_add_clinic_to_doctor_when_add_clinic_to_doctor_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validAddClinicToDoctorCommand);
            Assert.IsTrue(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handler")]
        public void Should_stop_execution_when_remove_clinic_of_doctor_command_is_invalid()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidRemoveClinicOfDoctorCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handler")]
        public void Should_remove_clinic_of_doctor_when_remove_clinic_of_doctor_command_is_valid()
        {
            _result = (GenericCommandResult)_handler.Handle(_validRemoveClinicOfDoctorCommand);
            Assert.IsTrue(_result.Success);
        }

    }
}
