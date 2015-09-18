using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P64
{
    // term = a + 1 / (m  / (sqrt(...) - n))
    struct SqrtExpansionTerm
    {
        public int a;
        public int m;
        public int n;

        public override string ToString()
        {
            return string.Format("{0} + (sqrt - {1}) / {2}", a, n, m);
        }
    }

    // [a0; a1, a2, ..., an]
    class ContinuedFraction
    {
        public int a0;
        public int[] a;

        public override string ToString()
        {
            return string.Format("[{0}, ({1})], period={2}", a0, string.Join(", ", a), a.Count());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //foreach(var t in SqrtExpansion(10).Take(10))
            //{
            //    t.Dump();
            //}

            //SqrtPeriodicNotation(16).Dump();

            int oddPeriod = 0;

            for (int x = 2; x <= 10000; x++)
            {
                int q = (int)Math.Round(Math.Sqrt(x));

                // check only irrational (a^k: 4, 9, 16, 25 ... can not be expanded as irrational sqrt)
                if (q * q != x)
                {
                    var periodicNotation = SqrtPeriodicNotation(x);

                    if (periodicNotation.a.Length % 2 == 1)
                    {
                        oddPeriod += 1;
                    }
                }
            }

            oddPeriod.Dump("Amount of N <= 10000 with sqrt of which have odd period of periodic expansion.");
        }

        static public ContinuedFraction SqrtPeriodicNotation(int x)
        {
            HashSet<SqrtExpansionTerm> terms = new HashSet<SqrtExpansionTerm>(); // to find when term will repeat some term in past to find period

            foreach (var term in SqrtExpansion(x).Skip(1))
            {
                if (!terms.Contains(term))
                {
                    terms.Add(term);
                } else
                {
                    break;
                }
            }

            return new ContinuedFraction()
            {
                a0 = SqrtExpansion(x).First().a,
                a = SqrtExpansion(x).Skip(1).Take(terms.Count).Select(t => t.a).ToArray(),
            };;
        }

        static public IEnumerable<SqrtExpansionTerm> SqrtExpansion(int x)
        {
            // first term calculation
            SqrtExpansionTerm prev = new SqrtExpansionTerm()
            {
                a = (int)Math.Floor(Math.Sqrt(x)),
                m = 1,
            };
            prev.n = prev.a;

            yield return prev;

            while(true)
            {
                int commonDivisor = x - prev.n * prev.n;

                Expectations.Expect(commonDivisor % prev.m == 0);

                commonDivisor /= prev.m;

                int surplus = prev.n;
                int a = (int)Math.Floor((Math.Sqrt(x) + surplus) / (double)commonDivisor);

                SqrtExpansionTerm current = new SqrtExpansionTerm()
                {
                    a = a,
                    m = commonDivisor,
                    n = -1 * (surplus - a * commonDivisor),
                };

                yield return current;
                prev = current;
            }
        }
    }
}
