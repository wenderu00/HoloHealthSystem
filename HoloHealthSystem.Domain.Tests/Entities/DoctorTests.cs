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
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_add_an_unregistered_clinic()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_remove_a_registered_clinic()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_remove_an_unregistered_clinic()
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
