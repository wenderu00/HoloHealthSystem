using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.Entities
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_modify_the_room_number_for_a_new_number_that_causes_no_conflict()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_modify_the_room_number_for_a_new_number_that_causes_conflict()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_without_conflict()
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
        public void Dado_uma_reserva_com_conflito_de_horario_nao_adiciona()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_add_a_repeated_reservation()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_a_new_reservation_without_any_time_conflict()
        {
            Assert.Fail();
        }
        public void Should_remove_an_existing_reservation()
        {
            Assert.Fail();
        }
        public void Should_not_remove_a_non_existing_reservation()
        {
            Assert.Fail();
        }
    }
}
