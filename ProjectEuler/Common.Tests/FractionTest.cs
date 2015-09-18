using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass]
    public class FractionTest
    {
        [TestMethod]
        public void FractionSumTest1()
        {
            var f = Fraction.Create(1, 2) + Fraction.Create(10, 20);

            f.Simplify();

            Assert.AreEqual(1m, (decimal)f);
        }

        [TestMethod]
        public void FractionSumTest2()
        {
            var r = Fraction.Create(1, 2) + Fraction.Create(1, 6);

            Assert.AreEqual(decimal.Divide(4, 6), (decimal)r);
        }

        [TestMethod]
        public void FractionDivTest1()
        {
            Assert.AreEqual(decimal.Divide(3, 16), (decimal)(Fraction.Create(3, 4) / Fraction.Create(8, 2)));
        }
    }
}
