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
    public class ClinicTests
    {
        private readonly State _state;
        private readonly City _city;
        private readonly Address _address;
        private readonly Address _address2;
        private readonly Clinic _clinic;
        private readonly Clinic _clinic2;
        private readonly Phone _validPhone;
        private readonly Phone _invalidPhone;
        private readonly Room _room;
        private readonly Manager _manager;
        private readonly Doctor _doctor;
        public ClinicTests()
        {
            _state = new State("Pernambuco");
            _city = new City(_state, "Recife");
            _clinic = new Clinic("Rua da hora");
            _clinic2 = new Clinic("Pedro leal");
            _address = new Address("pina", "rua da hora", "202", _clinic);
            _address2 = new Address("pina", "rua da hora", "203", _clinic2);
            _validPhone = new Phone("81996049871");
            _invalidPhone = new Phone("");
            _room = new Room("203", _clinic);
            _manager = new Manager(_clinic, new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
            _doctor = new Doctor("12345678", 0, new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_a_address_when_a_related_address_is_given()
            _
        {
            _clinic.AddAddress(_address);
            Assert.AreEqual(_address, _clinic.Address);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_address_when_a_not_related_address_is_given()
        {
            _clinic.AddAddress(_address2);
            Assert.AreEqual(null, _clinic.Address);
            
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_phone-number_when_a_invalid_phone-number_is_given()
        {
            var count = _clinic.Phones.Count;
            _clinic.AddPhone(_invalidPhone);
            Assert.AreEqual(count, _clinic.Phones.Count);
            
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_an_existing_phone-number()
        {
            _clinic.AddPhone(_validPhone);
            var count = _clinic.Phones.Count;
            _clinic.AddPhone(_validPhone);
            Assert.AreEqual(count, _clinic.Phones.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_a_valid_phone-number()
        {
            var count = _clinic.Phones.Count;
            _clinic.AddPhone(_validPhone);
            Assert.AreEqual(count+1, _clinic.Phones.Count);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_a_registered_phone-number()
        {
            
            _clinic.AddPhone(_validPhone);
            var count = _clinic.Phones.Count;
            _clinic.RemovePhone(_validPhone);
            Assert.AreEqual(count-1, _clinic.Phones.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_an_unregistered_phone-number()
        {

            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_an_existing_room_number()
        {
            _clinic.AddRoom(_room);
            var result= _clinic.HasRoomNumber(_room.Number);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_non_existing_room_number()
        {
            var result = _clinic.HasRoomNumber(_room.Number);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_registered_room()
        {
            
            _clinic.AddRoom(_room);
            var count = _clinic.Rooms.Count;
            _clinic.AddRoom(_room);
            Assert.AreEqual(count, _clinic.Rooms.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_room_with_a_registered_number()
        {

            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_a_new_room_that_has_no_number_conflicts()
        {
            var count = _clinic.Rooms.Count;
            _clinic.AddRoom(_room);
            Assert.AreEqual(count+1,_clinic.Rooms.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_registered_manager()
        {
            
            _clinic.AddManager(_manager);
            var count = _clinic.Managers.Count;
            _clinic.AddManager(_manager);
            Assert.AreEqual(count, _clinic.Managers.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_a_registered_manager()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_a_unregistered_manager()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_an_unregistered_manager()
        {
            var count = _clinic.Managers.Count;
            _clinic.AddManager(_manager);
            Assert.AreEqual(count+1, _clinic.Managers.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_registered_doctor()
        {
            _clinic.AddDoctor(_doctor);
            var count = _clinic.Doctors.Count;
            _clinic.AddDoctor(_doctor);
            Assert.AreEqual(count, _clinic.Doctors.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_an_unregistered_doctor()
        {
            var count = _clinic.Doctors.Count;
            _clinic.AddDoctor(_doctor);
            Assert.AreEqual(count + 1, _clinic.Doctors.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_a_registered_doctor()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_a_unregistered_doctor()
        {
            Assert.Fail();
        }
    }
}
