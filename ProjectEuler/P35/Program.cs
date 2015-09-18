using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P35
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimesUtilities.PrecalculateEratosphenPrimesTo(1000000);

            int answer = 0;
            for (int i = 2; i < 1000000; i++)
            {
                bool allPrime = true;

                foreach (var item in Circular(i))
                {
                    if (!PrimesUtilities.IsPrime(item))
                    {
                        allPrime = false;
                    }
                }

                if (allPrime)
                {
                    i.Dump();
                    answer += 1;
                }
            }

            answer.Dump("Solution");
        }

        static IEnumerable<int> Circular(int x)
        {
            string s = x.ToString();
            int n = s.Length;

            for (int i = 0; i < n; i++)
            {
                char[] cur = s.ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    cur[j] = s[(j + i) % n];
                }

                yield return int.Parse(new string(cur));
            }
        }

        // P37
        static IEnumerable<int> Trunctate(int x)
        {
            string s = x.ToString();
            int n = s.Length;

            yield return x;

            // tructate from right to left
            for (int i = 1; i < n; i++)
            {
                s = s.Substring(0, s.Length - 1);

                yield return int.Parse(s);
            }

            s = x.ToString();

            // tructate from left to right
            for (int i = 1; i < n; i++)
            {
                s = s.Substring(1, s.Length - 1);

                yield return int.Parse(s);
            }
        }
    }
}
