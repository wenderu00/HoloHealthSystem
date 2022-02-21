using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Tests.Entities
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_reservation_with_beginning_and_a_end()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_without_beginning_and_a_end()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_if_the_end_of_a_reservation_is_between_the_beginning_and_the_end()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_without_end_between_the_beginning_and_the_end()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_reservation_between_a_beginning_and_a_end()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_out_of_beginning_and_end_interval()
        {
            Assert.Fail();
        }
        
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_true_for_a_reservation_with_conflict()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_return_false_for_a_reservation_without_conflic()
        {
            Assert.Fail();
        }
    }
}
