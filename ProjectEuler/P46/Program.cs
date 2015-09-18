using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P46
{
    class Program
    {
        const int max = 1000000;
        static List<long> primes = PrimesUtilities.CalcEratosphenPrimes(max).ToList();

        static void Main(string[] args)
        {
            foreach (var n in OddCompositeNumbers())
            {
                if (!CanBeWritenAsPrimePlusTwiseSquare(n))
                {
                    n.Dump("Answer");

                    break;
                }
            }
        }

        static IEnumerable<int> OddCompositeNumbers()
        {
            for (int i = 3; i < max; i += 2)
            {
                if (!primes.Contains(i))
                {
                    yield return i;
                }
            }
        }

        static bool CanBeWritenAsPrimePlusTwiseSquare(long x)
        {
            foreach (var prime in primes)
            {
                if (prime >= x)
                {
                    break;
                }

                long d = x - prime;

                if (d % 2 == 0 && IsSquare(d / 2))
                {
                    Console.WriteLine(string.Format("{0} = {1} + 2x{2}^2", x, prime, (int)Math.Round(Math.Sqrt(d / 2))));

                    return true;
                }
            }

            return false;
        }

        static bool IsSquare(long x)
        {
            return (long)(Math.Round(Math.Sqrt(x)) * Math.Round(Math.Sqrt(x))) == x;
        }

    }
}
