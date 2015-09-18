using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P23
{
    class Program
    {
        static void Main(string[] args)
        {
            const int max = 28124;

            var abundant = Abundant(max);

            abundant.Count().Dump();

            var canBeRepresentedAsSum = new HashSet<long>(
                CombinatoricsUtilities.Pairs(abundant, true)
                .Select(p => p.Item1 + p.Item2));

            long s = 0;
            long amount = 0;


            for (int x = 1; x < max; x++)
            {
                if (!canBeRepresentedAsSum.Contains(x))
                {
                    s += x;
                    amount += 1;
                }
            }

            s.Dump("solution");
            amount.Dump("amount");
        }

        static IEnumerable<long> Abundant(long max)
        {
            for (long x = 1; x < max; x++)
            {
                long s = Basic.ProperDivisors(x).Sum();

                if (s > x)
                {
                    yield return x;
                }
            }
        }
    }
}
