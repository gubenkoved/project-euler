using Common;
using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class P93
    {
        /// <summary>
        /// This is ALMOST solution, but some bracket logic not correct...
        /// I was able to get right answer from the output though...
        /// </summary>
        public static void Run()
        {
            Solve();

            //var accessible = new List<decimal>();

            //Gen(new decimal[] { 0 }, new[] { 5, 7, 8, 9}, new List<int>(), accessible);

            //accessible
            //    .Select(x => (int)x)
            //    .MaxConsequentive()
            //    .Dump();
        }

        public static void Solve(int r = 4)
        {
            int max = -1;

            foreach (var perm in CombinatoricsUtilities.Permutations(Enumerable.Range(1, 9), 4))
            {
                var accessible = new List<decimal>();

                foreach (var d1 in perm)
                {
                    Gen(new decimal[] { d1 }, perm, new List<int>() { d1 }, accessible);
                }

                int cur = accessible
                    .Select(x => (int)x)
                    .MaxConsequentive();
                    //.Dump();

                if (cur > max)
                {
                    cur.Dump("Max conseq");
                    perm.Dump();
                    max = cur;
                }
            }
        }

        public static int MaxConsequentive(this IEnumerable<int> seq, int delta = 1)
        {
            seq = seq
                .Where(x => x > 0)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            if (seq.First() != 1)
            {
                return -1; // exclude seq where it's impossible to get 1
            }

            int prev = seq.First();
            foreach (var item in seq.Skip(1))
            {
                if (item - prev != delta)
                {
                    return prev;
                } else
                {
                    prev = item;
                }
            }

            return seq.Last();
        }

        public static void Gen(IEnumerable<decimal> dSource, IEnumerable<int> dAvailable, List<int> dUsed, List<decimal> accessible)
        {
            foreach (var ds in dSource.Distinct())
            {
                foreach (var da in dAvailable.Except(dUsed))
                {
                    dUsed.Add(da);

                    if (dUsed.Count == dAvailable.Count())
                    {
                        // end step
                        accessible.Add(ds * da);

                        accessible.Add(ds / da);
                        if (ds != 0) accessible.Add(da / ds);

                        accessible.Add(ds + da);

                        accessible.Add(ds - da);
                        accessible.Add(da - ds);
                    } else
                    {
                        // recourse ahead
                        Gen(dSource.Select(x => x * da), dAvailable, dUsed, accessible);

                        Gen(dSource.Select(x => x / da), dAvailable, dUsed, accessible);
                        Gen(dSource.Where(x => x != 0).Select(x => da / x), dAvailable, dUsed, accessible);

                        Gen(dSource.Select(x => x + da), dAvailable, dUsed, accessible);

                        Gen(dSource.Select(x => x - da), dAvailable, dUsed, accessible);
                        Gen(dSource.Select(x => da - x), dAvailable, dUsed, accessible);
                    }
                    

                    dUsed.Remove(da);
                }
            }
        }
    }
}
