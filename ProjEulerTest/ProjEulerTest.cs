﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjEulerTest
{
    [TestClass]
    public class ProjEulerTest
    {
        [TestMethod]
        [Timeout(60000)]
        public void Problem001Test()
        {
            Assert.AreEqual(23, ProjEuler.ProjEuler.Problem001(10));
            Assert.AreEqual(233168, ProjEuler.ProjEuler.Problem001(1000));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem002Test()
        {
            Assert.AreEqual(10, ProjEuler.ProjEuler.Problem002(13));
            Assert.AreEqual(44, ProjEuler.ProjEuler.Problem002(89));
            Assert.AreEqual(4613732, ProjEuler.ProjEuler.Problem002(4000000));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem003Test()
        {
            Assert.AreEqual(29, ProjEuler.ProjEuler.Problem003(13195));
            Assert.AreEqual(6857, ProjEuler.ProjEuler.Problem003(600851475143));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem004Test()
        {
            Assert.AreEqual(9009, ProjEuler.ProjEuler.Problem004(2));
            Assert.AreEqual(906609, ProjEuler.ProjEuler.Problem004(3));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem005Test()
        {
            Assert.AreEqual(2520, ProjEuler.ProjEuler.Problem005(1, 10));
            Assert.AreEqual(232792560, ProjEuler.ProjEuler.Problem005(1, 20));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem006Test()
        {
            Assert.AreEqual(2640, ProjEuler.ProjEuler.Problem006(10));
            Assert.AreEqual(25164150, ProjEuler.ProjEuler.Problem006(100));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem007Test()
        {
            Assert.AreEqual(13, ProjEuler.ProjEuler.Problem007(6));
            Assert.AreEqual(104743, ProjEuler.ProjEuler.Problem007(10001));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem008Test()
        {
            Assert.AreEqual(5832, ProjEuler.ProjEuler.Problem008(4));
            Assert.AreEqual(23514624000, ProjEuler.ProjEuler.Problem008(13));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem009Test()
        {
            Assert.AreEqual(31875000, ProjEuler.ProjEuler.Problem009());
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem010Test()
        {
            Assert.AreEqual(17, ProjEuler.ProjEuler.Problem010(10));
            Assert.AreEqual(142913828922, ProjEuler.ProjEuler.Problem010(2000000));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem011Test()
        {
            Assert.AreEqual(70600674, ProjEuler.ProjEuler.Problem011(4));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem012Test()
        {
            Assert.AreEqual(76576500, ProjEuler.ProjEuler.Problem012(4));
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem013Test()
        {
            Assert.AreEqual(5537376230, ProjEuler.ProjEuler.Problem013());
        }

        [TestMethod]
        [Timeout(60000)]
        public void Problem014Test()
        {
            Assert.AreEqual(837799, ProjEuler.ProjEuler.Problem014());
        }
    }
}
