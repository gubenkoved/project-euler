using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P38
{
    class Program
    {
        public static long m = 10000000L;

        static void Main(string[] args)
        {
            long solution = 0;

            for (long x = 1; x < m; x++)
            {
                List<long> nums = new List<long>();
                foreach(var p in Products(x))
                {
                    nums.Add(p);

                    long concatenatedProduct = long.Parse(string.Join("", nums));

                    if (concatenatedProduct > 1000L * 1000 * 1000 * 10)
                    {
                        break;
                    }

                    if (Pandigital(concatenatedProduct))
                    {
                        if (concatenatedProduct > solution)
                        {
                            solution = concatenatedProduct;
                        }

                        string.Format("{0,10}, {1}", x, concatenatedProduct).Dump();
                    }
                }
            }

            solution.Dump();
        }

        static bool Pandigital(long x)
        {
            string s = x.ToString();

            if (s.Length != 9)
            {
                return false;
            }

            foreach (var d in Enumerable.Range(1, 9))
            {
                if (!s.Contains(d.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        static IEnumerable<long> Products(long x)
        {
            long n = 0;
            do
            {
                n += 1;

                yield return x * n;

            } while (true);
        }
    }
}
