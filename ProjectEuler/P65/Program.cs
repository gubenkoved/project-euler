using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P65
{
    class Program
    {
        static void Main(string[] args)
        {
            //var f = ContinuedFraction.Create(1, new long[] {2, 2, 2, 2});

            //Evaluate(f).Dump();

            long[] a = ExponentContiniousFractionExpansion().Take(99).ToArray();

            for (int i = 0; i < 100; i++)
            {
                var cf = ContinuedFraction.Create(2, a.Take(i).ToArray());

                var f = cf.Evaluate();

                f.Dump();

                Basic.SumOfDigits_B(f.Numerator).Dump("sum of digits");
            }
        }

        //e = [2; 1,2,1, 1,4,1, 1,6,1 , ... , 1,2k,1, ...]
        static IEnumerable<long> ExponentContiniousFractionExpansion()
        {
            int k = 1;
            while(true)
            {
                yield return 1;
                yield return 2 * k;
                yield return 1;

                k += 1;
            }
        }
    }
}
