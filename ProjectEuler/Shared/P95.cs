using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class P95
    {
        private const int MAX = 1 * 1000 * 1000;

        private static int[] _sumOfDivisorsMap = new int[MAX + 1];

        private static void PreCalc2()
        {
            for (int div = 1; div < MAX; div++)
            {
                for (int x = div; x < MAX; x += div)
                {
                    if (x != div && x < _sumOfDivisorsMap.Length)
                    {
                        _sumOfDivisorsMap[x] += div;
                    }
                }
            }
        }

        public static void Run()
        {
            PreCalc2();

            //bool t;
            //TryGenerateChain(12496, out t).Dump();
            //t.Dump();

            //return;

            IEnumerable<int> longestChain = null;
            
            for (int x = 2; x < MAX; x++)
            {
                var chain = TryGenerateChain(x);

                if (chain != null &&
                    (longestChain == null || chain.Count() > longestChain.Count()))
                {
                    longestChain = chain;
                    longestChain.Dump();
                }
            }

            longestChain.Dump();
            longestChain.Min().Dump();
        }

        private static IEnumerable<int> TryGenerateChain(int x)
        {
            var rawChain = new List<int>();

            int current = x;
            rawChain.Add(current);

            do
            {
                current = _sumOfDivisorsMap[current];

                if (current == 1 || current > MAX)
                {
                    return null;
                }

                // already contains such number - chain!
                if (rawChain.Contains(current))
                {
                    int start = rawChain.IndexOf(current);

                    return rawChain.GetRange(start, rawChain.Count - start);
                }

                rawChain.Add(current);
            } while (true);
        }
    }
}
