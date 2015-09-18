using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class Primes
    {
        [TestMethod]
        public void CheckEratosphenPrimesGenerator()
        {
            Assert.AreEqual(78498, PrimesUtilities.CalcEratosphenPrimes(1000000).Count());
        }

        [TestMethod]
        public void CheckEratosphenPrimesGenerator50Millions()
        {
            Assert.AreEqual(3001134, PrimesUtilities.CalcEratosphenPrimes(50 * 1000 * 1000).Count());
        }
    }
}
