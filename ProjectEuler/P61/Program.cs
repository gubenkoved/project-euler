using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using System.Diagnostics;

namespace P61
{
    class Program
    {
        static void Main(string[] args)
        {
            Action solution = () =>
            {
                //foreach (var n in Enumerable.Range(1, 100000))
                //{
                //    long x = n * n * n;

                //    int len = x.ToString().Length;

                //    var permutations = CombinatoricsUtilities.Permutations(x.ToString().ToCharArray())
                //        .Select(v => new string(v))
                //        .Select(v => long.Parse(v))
                //        .Where(v => v.ToString().Length == len)
                //        .Distinct()
                //        .ToList();

                //    int cubesCount = 0;
                //    foreach (var v in permutations)
                //    {
                //        if (IsCube(v))
                //        {
                //            cubesCount += 1;
                //        }
                //    }

                //    string.Format("{0}={1}^3  cubes count: {2}", x, n, cubesCount).Dump();

                //    if (cubesCount == 5)
                //    {
                //        x.Dump("Solution");
                //        break;
                //    }
                //}

                IEnumerable<long> cubes = Cubes().Take(1000000);

                var facets = new Dictionary<string, HashSet<long>>();

                foreach (var x in cubes)
                {
                    long n = (long)Math.Round(Math.Pow(x, 1 / 3.0));

                    string s = new string(x.ToString().ToCharArray().OrderBy(c => c).ToArray());

                    if (!facets.ContainsKey(s))
                    {
                        facets[s] = new HashSet<long>();
                    }

                    facets[s].Add(x);
                    if (facets[s].Count == 5)
                    {
                        n.Dump("5");

                        facets[s].Min().Dump("solution");

                        break;
                    }
                }

            };

            solution.RunAndTime();
        }

        static public bool Permutable(IEnumerable<long> values)
        {
            var strings = values
                .Select(v => v.ToString().ToCharArray().OrderBy(c => c))
                .Select(c => new string(c.ToArray()))
                .ToList();


            return strings.Distinct().Count() == 1;
        }

        static public IEnumerable<long> Cubes()
        {
            long n = 1;
            while(true)
            {
                yield return n * n * n;

                n += 1;
            }
        }

        static public bool IsCube(long x)
        {
            long s = (long)Math.Round(Math.Pow(x, 1 / 3.0));

            return s * s * s == x;
        }
    }
}
