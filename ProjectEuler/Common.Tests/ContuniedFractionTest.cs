using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass]
    public class ContuniedFractionTest
    {
        [TestMethod]
        public void ContinuedFractionEvaluationTest()
        {
            // sqrt(2) = [1;(2)]
            //sqrt(2) convergents: 1, 3/2, 7/5, 17/12, 41/29, 99/70, 239/169, 577/408, 1393/985, 3363/2378

            var f = ContinuedFraction.Create(1, 2, 2, 2).Evaluate();

            f.Simplify();

            Assert.AreEqual((decimal)17 / 12, (decimal)f);
        }

        [TestMethod]
        public void ContinuedFractionEvaluationTest2()
        {
            // e = [2; 1,2,1, 1,4,1, 1,6,1 , ... , 1,2k,1, ...]
            //sqrt(2) convergents: 2, 3, 8/3, 11/4, 19/7, 87/32, 106/39, 193/71, 1264/465, 1457/536, ...

            var f = ContinuedFraction.Create(2, 1, 2, 1).Evaluate();

            f.Simplify();

            Assert.AreEqual((decimal)11 / 4, (decimal)f);
        }
    }
}
