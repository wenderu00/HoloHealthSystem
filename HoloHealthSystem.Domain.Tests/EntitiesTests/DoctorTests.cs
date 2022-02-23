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
    public class DoctorTests
    {
        private readonly Doctor _doctor;
        private readonly Clinic _clinic;
        private readonly Clinic _clinic2;
        private readonly Room _room;
        private readonly Reservation _reservation;
        private readonly Reservation _reservation2;
        private readonly Reservation _reservationWithConflict;
        public DoctorTests()
        {
            _clinic = new Clinic("Rua da hora");
            _clinic2 = new Clinic("Pedro leal");
            _doctor = new Doctor("12345678", 0, new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
            _room = new Room("203", _clinic);
            _reservation = new Reservation(_room, _doctor, DateTime.Now, DateTime.Now.AddMinutes(5));
            _reservation2 = new Reservation(_room, _doctor, DateTime.Now.AddMinutes(6), DateTime.Now.AddMinutes(10));
            _reservationWithConflict = new Reservation(_room, _doctor, DateTime.Now, DateTime.Now.AddMinutes(10));

        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_without_time_conflict()
        {
            _doctor.AddReservation(_reservation);
            bool result = _room.HasConflictReservation(_reservation2);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_reservation_with_time_conflict()
        {
            _doctor.AddReservation(_reservation);
            _doctor.AddReservation(_reservation2);
            bool result = _doctor.HasConflictReservation(_reservationWithConflict);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_registered_clinic()
        {
            _doctor.AddClinc(_clinic);
            var count = _doctor.Clinics.Count;
            _doctor.AddClinc(_clinic);
            Assert.AreEqual(count, _doctor.Clinics.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_an_unregistered_clinic()
        {
            var count = _doctor.Clinics.Count;
            _doctor.AddClinc(_clinic);
            Assert.AreEqual(count+1, _doctor.Clinics.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_a_registered_clinic()
        {
            _doctor.AddClinc(_clinic);
            var count = _doctor.Clinics.Count;
            _doctor.RemoveClinic(_clinic);
            Assert.AreEqual(count-1, _doctor.Clinics.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_an_unregistered_clinic()
        {
            _doctor.AddClinc(_clinic);
            var count = _doctor.Clinics.Count;
            _doctor.RemoveClinic(_clinic2);
            Assert.AreEqual(count, _doctor.Clinics.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_repeated_reservation()
        {
            _doctor.AddReservation(_reservation);
            var count = _doctor.Reservations.Count;
            _doctor.AddReservation(_reservation);
            Assert.AreEqual(count, _doctor.Reservations.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_reservation_that_has_any_conflict()
        {
            _doctor.AddReservation(_reservation);
            _doctor.AddReservation(_reservation2);
            var count = _doctor.Reservations.Count;
            _doctor.AddReservation(_reservationWithConflict);
            Assert.AreEqual(count, _doctor.Reservations.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_a_new_reservation_that_do_not_has_any_conflicts()
        {
            var count = _doctor.Reservations.Count;
            _doctor.AddReservation(_reservation);
            Assert.AreEqual(count+1, _doctor.Reservations.Count);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_a_registered_reservation()
        {
            _doctor.AddReservation(_reservation);
            var count = _doctor.Reservations.Count;
            _doctor.RemoveReservation(_reservation);
            Assert.AreEqual(count - 1, _doctor.Reservations.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_an_unregistered_reservation()
        {
            _doctor.AddReservation(_reservation);
            var count = _doctor.Reservations.Count;
            _doctor.RemoveReservation(_reservation2);
            Assert.AreEqual(count, _doctor.Reservations.Count);
        }
    }
}
