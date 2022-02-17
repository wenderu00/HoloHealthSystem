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
        public void Dado_um_endereco_diferente_Count_acrescemta_1()
        {
            var count = _city.Addresss.Count;
            _city.AddAddress(_address);
            Assert.AreEqual(count+1, _city.Addresss.Count);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_um_endereco_igual_count_permanece_igual()
        {
            
            _city.AddAddress(_address);
            var count = _city.Addresss.Count;
            _city.AddAddress(_address);
            Assert.AreEqual(count, _city.Addresss.Count);
        }
    }
}
