using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void GCDTest()
        {
            Assert.AreEqual(4, Basic.GCD(16, 12));
        }

        [TestMethod]
        public void LCMTest()
        {
            Assert.AreEqual(48, Basic.LCM(16, 12));
        }

        [TestMethod]
        public void SumOfDigitTest()
        {
            Assert.AreEqual(10, Basic.SumOfDigits(1234));
        }

        [TestMethod]
        public void SumOfDigitTest2()
        {
            Assert.AreEqual(0, Basic.SumOfDigits(0));
        }

        [TestMethod]
        public void SumOfDigitTest3()
        {
            Assert.AreEqual(1, Basic.SumOfDigits(1000));
        }
    }
}
