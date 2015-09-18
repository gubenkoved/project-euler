using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P49
{
    class Program
    {
        static void Main(string[] args)
        {
            SameElementsDelta(new int[] { 1487, 4817, 8147 });

            for (int x = 1234; x <= 9876; x++)
            {
                string s = x.ToString();

                var permutations = CombinatoricsUtilities.Permutations(s);

                HashSet<int> primes = new HashSet<int>();

                foreach (var p in permutations)
                {
                    string ps = new string(p);
                        
                    if (ps.TrimStart('0').Length != ps.Length)
                    {
                        continue;
                    }

                    int psi = int.Parse(ps);

                    if (PrimesUtilities.IsPrime(psi))
                    {
                        primes.Add(psi);
                    }
                }

                if (primes.Count >= 3)
                {
                    foreach (var primeSet in CombinatoricsUtilities.Permutations(primes, 3))
                    {
                        if (SameElementsDelta(primeSet))
                        {
                            primeSet.OrderBy(q => q).Dump();

                            break;
                        }
                    }
                }
            }

            //foreach(var p in CombinatoricsUtilities.Permutations(d, 4))
            //{

            //}
        }

        // 1, 4, 7, 10 -> true (+3 between all)
        public static bool SameElementsDelta(IEnumerable<int> seq)
        {
            List<int> seql = seq.OrderBy(e => e).ToList();

            int delta = seql[1] - seql[0];

            for (int i = 2; i < seql.Count; i++)
            {
                if (seql[i] - seql[i - 1] != delta)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
