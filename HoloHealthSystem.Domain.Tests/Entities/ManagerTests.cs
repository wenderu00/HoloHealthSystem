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
            _manager = new Manager(_clinic,new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
            _manager2 = new Manager(_clinic, new Email("facil@gmail.com"), new Name("Márcio", "Wendell"), DateTime.Now, new CPF("62318902364"));
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_change_clinic_when_old_clinic_has_one_or_more_manger()
        {
            _clinic.AddManager(_manager);
            _clinic.AddManager(_manager2);
            var clinic = _manager.Clinic;
            _manager.ChangeClinic(_clinic2);
            Assert.AreNotEqual(clinic, _manager.Clinic);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_change_clinic_when_old_clinic_dont_have_one_manger()
        {
            _clinic.AddManager(_manager);
            var clinic = _manager.Clinic;
            _manager.ChangeClinic(_clinic2);
            Assert.AreEqual(clinic, _manager.Clinic);
        }
    }
}
