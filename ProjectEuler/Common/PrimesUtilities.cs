using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PrimesUtilities
    {
        private static bool[] _precalculatedEratosphenNotPrimeArray;
        private static HashSet<long> _precalculatedPrimes = new HashSet<long>();
        private static long _precalculatedTo = 0;

        public static bool IsPrime(long x)
        {
            if (x <= 0)
            {
                return false;
            }

            if (x < _precalculatedTo)
            {
                return !_precalculatedEratosphenNotPrimeArray[x];
            } else if (x < Math.Sqrt(_precalculatedTo))
            {
                foreach (var prime in _precalculatedPrimes)
                {
                    if (x % prime == 0)
                    {
                        return false;
                    }
                }

                return true;
                
            } else
            {
                return IsPrimeSlow(x);
            }
        }

        private static bool IsPrimeSlow(long x)
        {
            if (x <= 1)
            {
                return false;
            }

            if (x == 2)
            {
                return true;
            }

            for (long i = 3; i < (long)(Math.Sqrt(x) + 1); i += 2)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void PrecalculateEratosphenPrimesTo(long max)
        {
            _precalculatedEratosphenNotPrimeArray = EratosphenNotPrimeArray(max);

            _precalculatedPrimes = new HashSet<long>();

            for (long i = 1; i < max; i++)
            {
                if (!_precalculatedEratosphenNotPrimeArray[i])
                {
                    _precalculatedPrimes.Add(i);
                }
            }

            _precalculatedTo = max;
        }

        public static IEnumerable<long> CalcEratosphenPrimes(long max)
        {
            var a = EratosphenNotPrimeArray(max);

            for (int i = 2; i < max; i++)
            {
                if (!a[i])
                {
                    yield return i;
                }
            }
        }

        public static bool[] EratosphenNotPrimeArray(long max)
        {
            Trace.Write(string.Format("ERATOSPHEN {0}. ", max));

            if (max > 2 * 1000 * 1000 * 1000)
            {
                throw new ArgumentException("2 billions is max prime value to prelculate using eratosphen seive");
            }

            var notPrime = new bool[max];

            Trace.Write("MEMORY ALLOCATED. ");

            notPrime[1] = true;

            Parallel.For(2, max, i =>
                {
                    while (notPrime[i])
                    {
                        i += 1;

                        if (i >= max)
                        {
                            break;
                        }
                    }

                    for (long j = 2 * i; j < max; j += i)
                    {
                        notPrime[j] = true;
                    }
                });

            Trace.WriteLine("DONE.");

            return notPrime;
        }

        private static double Progress(long k, long n)
        {
            double total    = Math.Log(n + 1) + 0.5772 - 1.0;
            double cur      = Math.Log(k + 1) + 0.5772 - 1.0;

            return cur / total;
        }
    }
}
