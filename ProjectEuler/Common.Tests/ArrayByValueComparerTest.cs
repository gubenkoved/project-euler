using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass]
    public class ArrayByValueComparerTest
    {
        [TestMethod]
        public void ArrayByValueComparer1()
        {
            var a = new[]
            {
                new [] { 1,2,3 },
                new [] { 1,3,1 },
                new [] { 1,2,2 },
                new [] { 1,2,3 },
                new [] { 1,3,1 },
            };

            Assert.AreEqual(3, a.Distinct(ArrayByValuesComparer<int>.Instance).Count());
        }

        [TestMethod]
        public void ArrayByValueComparerAllTheSame()
        {
            var a = new[]
            {
                new [] { 1,2,3 },
                new [] { 1,2,3 },
                new [] { 1,2,3 },
                new [] { 1,2,3 },
                new [] { 1,2,3 },
            };

            Assert.AreEqual(1, a.Distinct(ArrayByValuesComparer<int>.Instance).Count());
        }

        [TestMethod]
        public void ArrayByValueComparerDifferentLenSequences()
        {
            var a = new[]
            {
                new [] { 1, 2, 3},
                new [] { 1, 2, 3, 4},
                new [] { 1, 2, 3},
                new [] { 1, 2, 3, 4},
                new [] { 1, 2, 3, 4, 5},
            };

            Assert.AreEqual(3, a.Distinct(ArrayByValuesComparer<int>.Instance).Count());
        }
    }
}
