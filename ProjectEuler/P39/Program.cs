using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using System.Diagnostics;

namespace P39
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 1000;

            Dictionary<int, int> p = new Dictionary<int, int>();

            for (int a = 1; a < max; a++)
            {
                for (int b = a; b < max; b++)
                {

                    double cd = Math.Sqrt(a * a + b * b);

                    // check it integer

                    if (cd - Math.Floor(cd) > 0.00001)
                    {
                        continue;
                    }

                    int c = (int)Math.Round(cd);

                    int perimeter = a + b + c;

                    if (perimeter >= 1000)
                    {
                        continue;
                    }

                    if (!p.ContainsKey(perimeter))
                    {
                        p[perimeter] = 0;
                    } 

                    p[perimeter] += 1;
                }
            }

            foreach (var k in p.OrderByDescending(kvp => kvp.Value))
            {
                string.Format("Perimter {0, 5}, {1, 5} combinations", k.Key, k.Value).Dump();
            }
        }
    }
}
