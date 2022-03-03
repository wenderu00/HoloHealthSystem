using HoloHealthSystem.Domain.Commands.ReservationCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.CommandsTests.ReservationCommandsTests
{
    [TestClass]
    public class CreateReservationCommandTests
    {
        private readonly CreateReservationCommand _invalidCreateReservationCommand = new CreateReservationCommand();
        private readonly CreateReservationCommand _validCreateReservationCommand = new CreateReservationCommand(Guid.NewGuid(),"12345678",DateTime.Now,DateTime.Now.AddHours(5));
        
        public CreateReservationCommandTests()
        {
            _invalidCreateReservationCommand.Validate();
            _validCreateReservationCommand.Validate();
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_false_when_create_reservation_command_is_invalid()
        {
            Assert.IsFalse(_invalidCreateReservationCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_true_when_create_reservation_command_is_valid()
        {
            Assert.IsTrue(_validCreateReservationCommand.IsValid);
        }
    }
}
