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

        [TestMethod]
        public void Problem002Test()
        {
            Assert.AreEqual(10, ProjEuler.ProjEuler.Problem002(13));
            Assert.AreEqual(44, ProjEuler.ProjEuler.Problem002(89));
            Assert.AreEqual(4613732, ProjEuler.ProjEuler.Problem002(4000000));
        }

        [TestMethod]
        public void Problem003Test()
        {
            Assert.AreEqual(29, ProjEuler.ProjEuler.Problem003(13195));
            Assert.AreEqual(6857, ProjEuler.ProjEuler.Problem003(600851475143));
        }

        [TestMethod]
        public void Problem004Test()
        {
            Assert.AreEqual(9009, ProjEuler.ProjEuler.Problem004(2));
            Assert.AreEqual(906609, ProjEuler.ProjEuler.Problem004(3));
        }
    }
}
