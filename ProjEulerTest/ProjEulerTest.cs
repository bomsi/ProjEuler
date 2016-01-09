using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjEulerTest
{
    [TestClass]
    public class ProjEulerTest
    {
        [TestMethod]
        public void Problem001Test()
        {
            Assert.AreEqual(23, ProjEuler.ProjEuler.Problem001(10));
            Assert.AreEqual(233168, ProjEuler.ProjEuler.Problem001(1000));
        }
    }
}
