using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace P53
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = 0;

            Action solution = () =>
                {
                    for (int n = 1; n <= 100; n++)
                    {

                        for (int k = 1; k <= 100; k++)
                        {
                            if (NumOfCombinations(k, n) > 1000 * 1000)
                            {
                                r += 1;
                            }
                        }

                        n.Dump();
                    }
                };

            solution.RunAndTime("Solution time");

            r.Dump();
        }

        static BigInteger NumOfCombinations(int k, int n)
        {
            // c (k, n) = n! / (n - k)! k!
            return Fact(n) / (Fact(n - k) * Fact(k));
        }

        static CacheProxy<int, BigInteger> _cache;
        static BigInteger Fact(int x)
        {
            if (_cache == null)
            {
                _cache = CacheProxy.For((int xx) => FactImpl(xx));
            }

            return _cache.Invoke(x);
        }

        static BigInteger FactImpl(int x)
        {
            if (x <= 1)
            {
                return new BigInteger(1);
            }
            else
            {
                return BigInteger.Multiply(new BigInteger(x), Fact(x - 1));
            }
        }
    }
}
