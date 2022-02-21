using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.Entities
{
    [TestClass]
    public class ReservationTests
    {
        private readonly Clinic _clinic;
        private readonly Room _room;
        private readonly Doctor _doctor;
        private readonly Pacient _pacient;
        private readonly Reservation _reservation;
        private readonly Reservation _reservation2;
        private readonly Reservation _reservation3;
        private readonly Reservation _reservation4;
        private readonly Apointment _validApoint;
        private readonly Apointment _invalidApoint;

        public ReservationTests()
        {
            _clinic = new Clinic("Rua da hora");
            _room = new Room("203", _clinic);
            _doctor = new Doctor("12345678", 0, new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
            _reservation = new Reservation(_room, _doctor, DateTime.Now.AddMinutes(2), DateTime.Now.AddMinutes(5));
            _reservation2 = new Reservation(_room, _doctor, DateTime.Now.AddMinutes(4), DateTime.Now.AddMinutes(6));
            _reservation3 = new Reservation(_room, _doctor, DateTime.Now.AddMinutes(1), DateTime.Now.AddMinutes(7));
            _reservation4 = new Reservation(_room, _doctor, DateTime.Now.AddMinutes(6), DateTime.Now.AddMinutes(7));
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_if_the_begin_of_reservation_is_between_beginning_and_a_end()
        {
            bool result = _reservation.BeginBetween(_reservation2);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_if_the_begin_of_reservation_without_between_beginning_and_a_end()
        {
            bool result = _reservation2.BeginBetween(_reservation);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_if_the_end_of_a_reservation_is_between_the_beginning_and_the_end()
        {
            bool result = _reservation2.EndBetween(_reservation);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_without_end_between_the_beginning_and_the_end()
        {
            bool result = _reservation.EndBetween(_reservation2);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_reservation_between_a_beginning_and_a_end()
        {
            bool result = _reservation.ReservationBetween(_reservation3);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_out_of_beginning_and_end_interval()
        {
            bool result = _reservation3.ReservationBetween(_reservation2);
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_reservation_with_conflict()
        {
            bool result = _reservation3.HasConflictTime(_reservation2);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_without_conflic()
        {
            bool result = _reservation4.HasConflictTime(_reservation2);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_valid_apointment()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_invalid_apointment()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_conflict_apointment()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_conflictless_apointment()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_invalid_apointment()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_registered_apointment()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_conflict_apointment()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_new_valid_apointment_that_do_not_has_any_conflicts()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_a_registered_apointment()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_an_unregistered_apointment()
        {
            Assert.Fail();
        }
    }
}
