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
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_change_clinic_when_old_clinic_has_one_or_more_manger()
        {
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Should_not_change_clinic_when_old_clinic_dont_have_one_manger()
        {
            Assert.Fail();
        }
    }
}
