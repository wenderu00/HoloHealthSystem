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
    public class ManagerTests
    {
        private readonly Manager _manager;
        private readonly Manager _manager2;
        private readonly Clinic _clinic;
        private readonly Clinic _clinic2;
        public ManagerTests()
        {
            _clinic = new Clinic("rua da hora");
            _clinic2 = new Clinic("rua das horas");
            _manager = new Manager(new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
            _manager2 = new Manager( new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_change_clinic_when_clinic_is_null()
        {
            
            _manager.ChangeClinic(_clinic);
            Assert.AreEqual(_clinic, _manager.Clinic);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_change_clinic_when_old_clinic_has_one_or_more_manger()
        {
            _clinic.AddManager(_manager);
            _manager.ChangeClinic(_clinic);
            _clinic.AddManager(_manager2);
            _manager2.ChangeClinic(_clinic);
            var clinic = _manager.Clinic;
            _manager.ChangeClinic(_clinic2);
            Assert.AreNotEqual(clinic, _manager.Clinic);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_change_clinic_when_old_clinic_dont_have_one_manger()
        {
            _clinic.AddManager(_manager);
            _manager.ChangeClinic(_clinic);
            var clinic = _manager.Clinic;
            _manager.ChangeClinic(_clinic2);
            Assert.AreEqual(clinic, _manager.Clinic);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_clinic_when_manager_clinic_is_null()
        {
            var clinic = _manager.Clinic;
            _manager.RemoveClinic(_clinic);
            Assert.AreEqual(clinic, _manager.Clinic);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_clinic_when_manager_clinic_are_not_equal()
        {
            _manager.ChangeClinic(_clinic2);
            var clinic = _manager.Clinic;
            _manager.RemoveClinic(_clinic);
            Assert.AreEqual(clinic, _manager.Clinic);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_clinic_when_manager_clinic_are_equal()
        {
            _manager.ChangeClinic(_clinic);
            _manager.RemoveClinic(_clinic);
            Assert.AreEqual(null, _manager.Clinic);
        }
    }
}
