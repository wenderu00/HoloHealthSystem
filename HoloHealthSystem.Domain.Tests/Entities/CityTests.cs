using HoloHealthSystem.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.Entities
{
    [TestClass]
    public class CityTests
    {
        private readonly State _state;
        private readonly City _city;
        private readonly Clinic _clinic;
        private readonly Address _address;

        public CityTests()
        {
            _state = new State("Pernambuco");
            _city = new City(_state, "Recife");
            _clinic = new Clinic("Rua da hora");
            _address = new Address("pina", "rua da hora", "202", _clinic);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_an_unregistered_address()
        {
            var count = _city.Addresss.Count;
            _city.AddAddress(_address);
            Assert.AreEqual(count+1, _city.Addresss.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_registered_address()
        {
            
            _city.AddAddress(_address);
            var count = _city.Addresss.Count;
            _city.AddAddress(_address);
            Assert.AreEqual(count, _city.Addresss.Count);
        }
    }
}
