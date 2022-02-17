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
    public class StateTests
    {
        private readonly State _state;
        private readonly City _city;

        public StateTests()
        {
           _state = new State("Pernambuco");
           _city = new City(_state, "Recife");
        }
        

        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_uma_cidade_nova_o_count_acrescenta_1()
        {
            var count = _state.Cities.Count;
            _state.AddCity(_city);
            Assert.AreEqual(count+1, _state.Cities.Count);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_uma_cidade_repetida_o_count_permaece_igual()
        {
            _state.AddCity(_city);
            var count = _state.Cities.Count;
            _state.AddCity(_city);
            Assert.AreEqual(count, _state.Cities.Count);
        }
    }
}
