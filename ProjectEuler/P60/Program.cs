using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P60
{
    class Program
    {
        public static bool[] EratosphenArray;
        public static List<long> Primes;

        public static long MaxPrimePosition = 1500;

        public static long MaxPrimeToGenerate = 1024 * 1024 * 16;

        static void Main(string[] args)
        {
            Primes = PrimesUtilities.CalcEratosphenPrimes(MaxPrimeToGenerate).ToList();
            EratosphenArray = PrimesUtilities.EratosphenNotPrimeArray(MaxPrimeToGenerate);

            foreach (var setOf5 in Generate5())
            {
                Console.Write("+");

                setOf5.Dump("TRUE");
            }

            "Done".Dump();

            Console.ReadKey();
        }

        static IEnumerable<long[]> Generate5()
        {
            for (int i1 = 0; i1 < MaxPrimePosition; i1++)
            {
                for (int i2 = i1 + 1; i2 < MaxPrimePosition; i2++)
                {
                    if (!ComposesPrimePairsWith(Primes[i2], new[] { Primes[i1] }))
                    {
                        continue;
                    }

                    //new[] { Primes[i1], Primes[i2] }.Dump();

                    for (int i3 = i2 + 1; i3 < MaxPrimePosition; i3++)
                    {
                        if (!ComposesPrimePairsWith(Primes[i3], new[] { Primes[i1], Primes[i2] }))
                        {
                            continue;
                        }

                        //new[] { Primes[i1], Primes[i2], Primes[i3] }.Dump();

                        for (int i4 = i3 + 1; i4 < MaxPrimePosition; i4++)
                        {
                            if (!ComposesPrimePairsWith(Primes[i4], new[] { Primes[i1], Primes[i2], Primes[i3] }))
                            {
                                continue;
                            }

                            new[] { Primes[i1], Primes[i2], Primes[i3], Primes[i4] }.Dump();

                            for (int i5 = i4 + 1; i5 < MaxPrimePosition; i5++)
                            {
                                if (!ComposesPrimePairsWith(Primes[i5], new[] { Primes[i1], Primes[i2], Primes[i3], Primes[i4] }))
                                {
                                    continue;
                                }

                                yield return new long[] 
                                { 
                                    Primes[i1], 
                                    Primes[i2], 
                                    Primes[i3], 
                                    Primes[i4], 
                                    Primes[i5],
                                };
                            }
                        }
                    }
                }
            }
        }

        static public Dictionary<Tuple<long, long>, long> _mergeCache = new Dictionary<Tuple<long, long>, long>();

        static long Merge(long l1, long l2)
        {
            if (l1 < 10000 || l2 < 10000)
            {
                var t = Tuple.Create(l1, l2);

                if (!_mergeCache.ContainsKey(t))
                {
                    _mergeCache[t] = MergeImpl(l1, l2);
                }

                return _mergeCache[t];
            }
            
            return MergeImpl(l1, l2);
        }

        static long MergeImpl(long l1, long l2)
        {
            int l2Len = (int)Math.Ceiling(Math.Log10(l2));

            return l1 * (long)Math.Pow(10, l2Len) + l2;
        }

        static bool ComposesPrimePairsWith(long d, IEnumerable<long> primes)
        {
            foreach (var p in primes)
            {
                if (!IsPrime(Merge(d, p))
                    || !IsPrime(Merge(p, d)))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsPrime(long d)
        {
            if (d > MaxPrimeToGenerate)
            {
                if (Math.Sqrt(d) > MaxPrimeToGenerate )
                {
                    throw new InvalidOperationException();
                }

                foreach (var p in Primes)
                {
                    if (d % p == 0)
                    {
                        return false;
                    }
                }

                return true;
            }

            return EratosphenArray[d] == false;
        }

        static bool Check(IEnumerable<long> data)
        {
            foreach (var pair in GetPairs(data))
            {
                var p = Merge(pair.Item1, pair.Item2);

                if (!IsPrime(p))
                {
                    return false;
                }
            }

            return true;
        }

        static IEnumerable<Tuple<T, T>> GetPairs<T>(IEnumerable<T> data)
        {
            var a = data.ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (i != j)
                    {
                        yield return Tuple.Create(a[i], a[j]);
                    }
                }
            }
        }
    }
}
