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
    public class DoctorTests
    {
        private readonly Doctor _doctor;
        private readonly Clinic _clinic;
        private readonly Clinic _clinic2;
        public DoctorTests()
        {
            _clinic = new Clinic("Rua da hora");
            _clinic2 = new Clinic("Pedro leal");
            _doctor = new Doctor("12345678", 0, new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_without_time_conflict()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_reservation_with_time_conflict()
        {
            Assert.Fail();
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
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_reservation_that_has_any_conflict()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_a_new_reservation_that_do_not_has_any_conflicts()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_a_registered_reservation()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_an_unregistered_reservation()
        {
            Assert.Fail();
        }
    }
}
