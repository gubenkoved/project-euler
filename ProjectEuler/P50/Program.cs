using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P50
{
    class Program
    {
        static List<long> Primes = PrimesUtilities.CalcEratosphenPrimes(100000).ToList();
        static HashSet<long> PrimesToCheck = new HashSet<long>(PrimesUtilities.CalcEratosphenPrimes(1000000));

        static void Main(string[] args)
        {
            List<long> cumulative = Cumulative(Primes);

            for (int len = Primes.Count - 1; len >= 2; len--)
            {
                Console.WriteLine("LEN " + len.ToString());

                for (int startingAt = 1; startingAt < Primes.Count - len + 1; startingAt++)
                {
                    //long sum = SumRange(Primes, startingAt, len);

                    long sum = cumulative[startingAt + len - 1] - cumulative[startingAt - 1];

                    if (sum < 1000000)
                    {
                        if (PrimesToCheck.Contains(sum))
                        {
                            var p = Primes.Skip(startingAt).Take(len);

                            Console.WriteLine(string.Format("{0} = {1}", sum, string.Join(" + ", p)));

                            goto end;
                        }
                    }
                }
            }

        end:

            Console.WriteLine("the end");
        }

        // to fast range summing
        static List<long> Cumulative(List<long> l)
        {
            long[] r = new long[l.Count];

            r[0] = l[0];

            for (int i = 1; i < l.Count; i++)
            {
                r[i] = r[i - 1] + l[i];
            }

            return r.ToList();
        }

        static long SumRange(List<long> l, int startingAt, int len)
        {
            long sum = 0;
            for (int i = startingAt; i < startingAt + len; i++)
            {
                sum += l[i];
            }

            return sum;
        }
    }
}
