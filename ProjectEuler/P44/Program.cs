using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P44
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = Pentagonal().Take(10000).ToList();
            
            var pc = new HashSet<long>(Pentagonal().Take(p.Count * 2));

            long min = -1;

            for (int i = 0; i < p.Count - 1; i++)
            {
                for (int j = i + 1; j < p.Count; j++)
                {
                    long sum = p[i] + p[j];
                    long dif = p[j] - p[i];

                    bool sumPent = pc.Contains(sum);
                    bool difPent = pc.Contains(dif);

                    //Console.WriteLine(string.Format("{0, 10} {1, 10}, S = {2, 10} ({4, 5}), D = {3, 10} ({5, 5})", p[i], p[j], sum, dif, sumPent, difPent));

                    if (sumPent && difPent)
                    {
                        Console.WriteLine(string.Format("!! {0, 10} {1, 10}, S = {2, 10} ({4, 5}), D = {3, 10} ({5, 5})", p[i], p[j], sum, dif, sumPent, difPent));

                        if (dif < min || min == -1)
                        {
                            min = dif;

                            //string.Format("{0}, {1}, D = {2}", p[i], p[j], dif);
                        }
                    }
                }
            }

            Console.WriteLine(min);
        }

        static IEnumerable<long> Pentagonal()
        {
            int n = 1;
            while (true)
            {
                // n(3n−1)/2.

                yield return n * (3 * n - 1) / 2;

                n += 1;
            }
        }
    }
}
