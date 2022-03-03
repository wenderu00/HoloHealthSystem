using HoloHealthSystem.Domain.Commands.Contracts;
using HoloHealthSystem.Domain.Commands.ReservationCommands;
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
    public class ReservationHandlerTests
    {
        private readonly CreateReservationCommand _invalidCreateReservationCommand = new CreateReservationCommand();
        private readonly CreateReservationCommand _validCreateReservationCommand = new CreateReservationCommand(Guid.NewGuid(), "12345678", DateTime.Now, DateTime.Now.AddHours(5));
        private readonly RemoveReservationCommand _invalidRemoveReservationCommand = new RemoveReservationCommand();
        private readonly RemoveReservationCommand _validRemoveReservationCommand = new RemoveReservationCommand(Guid.NewGuid());
        private readonly ReservationHandler _handler = new ReservationHandler(new FakeRoomRepository(),new FakeDoctorRepository(),new FakeReservationRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_invalid_create_reservation_command_is_given()
        {
            _result=(GenericCommandResult)_handler.Handle(_invalidCreateReservationCommand);
            Assert.IsFalse(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_execute_command_when_valid_create_reservation_command_is_given()
        {
            _result=(GenericCommandResult)_handler.Handle(_validCreateReservationCommand);
            Assert.IsTrue(_result.Success);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_stop_execution_when_invalid_remove_reservation_command_is_given()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Should_execute_command_when_valid_remove_reservation_command_is_given()
        {
            Assert.Fail();
        }
    }
}
