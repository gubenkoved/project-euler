using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Common.Tests
{
    [TestClass]
    public class CombinatoricsTest
    {
        [TestMethod]
        public void FullPermutationsTest()
        {
            var p = CombinatoricsUtilities.Permutations(new[] { 'a', 'b', 'c', 'd', 'e' });

            foreach (var item in p)
            {
                Trace.WriteLine(string.Join("", item.ToArray()));
            }

            Assert.AreEqual(5 * 4 * 3 * 2 * 1, p.Count());
        }

        [TestMethod]
        public void FullPermutationsTest2()
        {
            Assert.AreEqual(9 * 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1, 
                CombinatoricsUtilities.Permutations(123456789.ToString()).Count());
        }

        [TestMethod]
        public void FullPermutationsTest3()
        {
            Assert.AreEqual(1 * 2 * 3 * 4,
                CombinatoricsUtilities.Permutations(new [] { '1', '2', '3', '1'}).Count());
        }

        [TestMethod]
        public void FullPermutationsTest4()
        {
            Assert.AreEqual(10 * 9 * 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1,
                CombinatoricsUtilities.Permutations(1234567891.ToString()).Count());
        }

        [TestMethod]
        public void PartialPermutationsTest()
        {
            Assert.AreEqual(5 * 4, CombinatoricsUtilities.Permutations(new[] { 'a', 'b', 'c', 'd', 'e' }, 2).Count());
        }

        [TestMethod]
        public void PartialPermutationsTest2()
        {
            var a = CombinatoricsUtilities.Permutations(new[] { 'a', 'b', 'c', 'd', 'e' }, 3);

            foreach (var item in a)
            {
                Trace.WriteLine(string.Join("", item));
            }

            Assert.AreEqual(5 * 4 * 3, a.Count());
        }

        [TestMethod]
        public void PartialPermutationsTest3()
        {
            var chars = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
            var n = chars.Count();

            Assert.AreEqual(n * (n - 1) * (n - 2), CombinatoricsUtilities.Permutations(chars, 3).Count());
        }

        [TestMethod]
        public void PairsCount()
        {
            const int n = 100;
            var a = CombinatoricsUtilities.Pairs(Enumerable.Range(0, n));

            Assert.AreEqual(n * (n - 1), a.Count());
        }

        [TestMethod]
        public void PairsCountWithSelfPairs()
        {
            const int n = 100;
            var a = CombinatoricsUtilities.Pairs(Enumerable.Range(0, n), true);

            Assert.AreEqual(n * n, a.Count());
        }


    }
}
