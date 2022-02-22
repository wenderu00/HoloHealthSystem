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
    public class ApointmentTests
    {
        private readonly Clinic _clinic;
        private readonly Room _room;
        private readonly Doctor _doctor;
        private readonly Pacient _pacient;
        private readonly Reservation _reservation;
        private readonly Apointment _validApoint;
        private readonly Apointment _validApointWithConflict;
        private readonly Apointment _validApointConflictless;
        public ApointmentTests()
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
        public void Should_return_true_for_conflict_apointment()
        {
            bool result = _validApoint.HasConclictTime(_validApointWithConflict);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_not_conflict_apointment()
        {
            bool result = _validApoint.HasConclictTime(_validApointConflictless);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_done_is_false_when_create_apointment()
        {
            Assert.IsFalse(_validApoint.Done);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_done_is_true_after_call_markAsDone()
        {
            _validApoint.MarkAsDone();
            Assert.IsTrue(_validApoint.Done);
        }
    }
}
