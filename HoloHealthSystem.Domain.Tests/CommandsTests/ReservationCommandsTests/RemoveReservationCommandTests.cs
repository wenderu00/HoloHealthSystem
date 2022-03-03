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
    public class RemoveReservationCommandTests
    {
        private readonly RemoveReservationCommand _invalidRemoveReservationCommand = new RemoveReservationCommand();
        private readonly RemoveReservationCommand _validRemoveReservationCommand = new RemoveReservationCommand(Guid.NewGuid());

        public RemoveReservationCommandTests()
        {
            _invalidRemoveReservationCommand.Validate();
            _validRemoveReservationCommand.Validate();
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_false_when_remove_reservation_command_is_invalid()
        {
            Assert.IsFalse(_invalidRemoveReservationCommand.IsValid);
        }
        [TestMethod]
        [TestCategory("Commands")]
        public void Should_is_valid_return_true_when_remove_reservation_command_is_valid()
        {
            Assert.IsTrue(_validRemoveReservationCommand.IsValid);
        }
    }
}
