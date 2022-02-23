using HoloHealthSystem.Domain.Entities;
using HoloHealthSystem.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.EntitiesTests
{
    [TestClass]
    public class RoomTests
    {
        private readonly Clinic _clinic;
        private readonly Room _room;
        private readonly Room _room2;
        private readonly Reservation _reservation;
        private readonly Reservation _reservation2;
        private readonly Reservation _reservationWithConflict;
        private readonly Doctor _doctor;
        public RoomTests()
        {
            _clinic = new Clinic("Rua da hora");
            _room = new Room("203", _clinic);
            _room2 = new Room("204", _clinic);
            _doctor = new Doctor("12345678", 0, new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
            _reservation = new Reservation(_room, _doctor, DateTime.Now, DateTime.Now.AddMinutes(5));
            _reservation2 = new Reservation(_room, _doctor, DateTime.Now.AddMinutes(6), DateTime.Now.AddMinutes(10));
            _reservationWithConflict = new Reservation(_room, _doctor, DateTime.Now, DateTime.Now.AddMinutes(10));
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_modify_the_room_number_for_a_new_number_that_causes_no_conflict()
        {
            _clinic.AddRoom(_room);
            _clinic.AddRoom(_room2);
            var newNumber = "205";
            _room.UpdateNumber(newNumber);
            Assert.AreEqual(newNumber,_room.Number);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_modify_the_room_number_for_a_new_number_that_causes_conflict()
        {
            _clinic.AddRoom(_room);
            _clinic.AddRoom(_room2);
            var newNumber = "204";
            _room.UpdateNumber(newNumber);
            Assert.AreNotEqual(newNumber, _room.Number);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_without_conflict()
        {
            _room.AddReservation(_reservation);
            bool result = _room.HasConflictReservation(_reservation2);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_reservation_with_time_conflict()
        {
            _room.AddReservation(_reservation);
            _room.AddReservation(_reservation2);
            bool result = _room.HasConflictReservation(_reservationWithConflict);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_reservation_with_conflict_time() // Dado_uma_reserva_com_conflito_de_horario_nao_adiciona()
        {
            _room.AddReservation(_reservation);
            _room.AddReservation(_reservation2);
            var count = _room.Reservations.Count;
            _room.AddReservation(_reservationWithConflict);
            Assert.AreEqual(count, _room.Reservations.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_repeated_reservation()
        {
            _room.AddReservation(_reservation);
            _room.AddReservation(_reservation2);
            var count = _room.Reservations.Count;
            _room.AddReservation(_reservation);
            Assert.AreEqual(count, _room.Reservations.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_a_new_reservation_without_any_time_conflict()
        {
            var count = _room.Reservations.Count;
            _room.AddReservation(_reservation);
            Assert.AreEqual(count + 1, _room.Reservations.Count);

        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_an_existing_reservation()
        {
            _room.AddReservation(_reservation);
            var count = _room.Reservations.Count;
            _room.RemoveReservation(_reservation);
            Assert.AreEqual(count - 1, _room.Reservations.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_a_non_existing_reservation()
        {
            _room.AddReservation(_reservation);
            var count = _room.Reservations.Count;
            _room.RemoveReservation(_reservation2);
            Assert.AreEqual(count, _room.Reservations.Count);
        }
    }
}
