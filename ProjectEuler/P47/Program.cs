using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P47
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetLen = 4;
            int conseq = 0;
            int targetConseqAmount = 4;

            for (int x = 2; x <= 10000000; x++)
			{
                var f = Factorize(x);
                var df = DistinctFactors(f);

                //string.Format("{0, 5} = {1, 20} = {2, 20}", 
                //    x, 
                //    string.Join("x", f), 
                //    string.Join("x", c))
                //    .Dump();

                if (df.Count == targetLen)
                {
                    conseq += 1;
                } else
                {
                    conseq = 0;
                }

                if (conseq == targetConseqAmount)
                {
                    (x - targetConseqAmount + 1).Dump("answer");

                    break;
                }
			}
        }

        static HashSet<int> DistinctFactors(IEnumerable<int> factors)
        {
            return new HashSet<int>(factors);
        }

        static List<int> Factorize(int x)
        {
            for (int i = 2; i <= x; i++)
            {
                if (x % i == 0)
                {
                    var nested = Factorize(x / i);

                    nested.Add(i);

                    return nested;
                }
            }

            return new List<int>();
        }
    }
}
