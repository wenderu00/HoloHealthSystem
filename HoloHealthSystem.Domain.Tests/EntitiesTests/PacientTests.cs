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
    public class PacientTests
    {
        private readonly Clinic _clinic;
        private readonly Room _room;

        private readonly Apointment _validApoint;
        private readonly Apointment _validApointWithConflict;
        private readonly Apointment _validApointConflictless;
        private readonly Pacient _pacient;
        private readonly Reservation _reservation;
        private readonly Doctor _doctor;

        public PacientTests()
        {

            _clinic = new Clinic("Rua da hora");
            _room = new Room("203", _clinic);
            _doctor = new Doctor("12345678", 0, new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
            _reservation = new Reservation(_room, _doctor, DateTime.Now.AddMinutes(2), DateTime.Now.AddMinutes(5));
            _pacient = new Pacient(new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
            _validApoint = new Apointment(_pacient, _reservation, DateTime.Now.AddMinutes(3));
            _validApointWithConflict = new Apointment(_pacient, _reservation, DateTime.Now.AddMinutes(3));
            _validApointConflictless = new Apointment(_pacient, _reservation, DateTime.Now.AddMinutes(4));

        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_conflict_apointment()
        {
            _pacient.AddApointment(_validApoint);
            bool result = _pacient.HasConflictApointment(_validApointWithConflict);
            Assert.IsTrue(result);
            
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_conflictless_apointment()
        {
            _pacient.AddApointment(_validApoint);
            bool result = _pacient.HasConflictApointment(_validApointConflictless);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_registered_apointment()
        {
            _pacient.AddApointment(_validApoint);
            var count = _pacient.Apointments.Count;
            _pacient.AddApointment(_validApoint);
            Assert.AreEqual(count , _pacient.Apointments.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_conflict_apointment()
        {
            _pacient.AddApointment(_validApoint);
            var count = _pacient.Apointments.Count;
            _pacient.AddApointment(_validApointWithConflict);
            Assert.AreEqual(count, _pacient.Apointments.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_new_valid_apointment_that_do_not_has_any_conflicts()
        {
            var count = _pacient.Apointments.Count;
            _pacient.AddApointment(_validApoint);
            Assert.AreEqual(count+1, _pacient.Apointments.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_a_registered_apointment()
        {
            _pacient.AddApointment(_validApoint);
            var count = _pacient.Apointments.Count;
            _pacient.RemoveApointment(_validApoint);
            Assert.AreEqual(count-1, _pacient.Apointments.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_an_unregistered_apointment()
        {
            _pacient.AddApointment(_validApoint);
            var count = _pacient.Apointments.Count;
            _pacient.RemoveApointment(_validApointConflictless);
            Assert.AreEqual(count , _pacient.Apointments.Count);
        }
    }
}
