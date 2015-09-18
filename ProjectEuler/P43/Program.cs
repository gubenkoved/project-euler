using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43
{
    class Program
    {
        static void Main(string[] args)
        {
            //d2d3d4=406 is divisible by 2
            //d3d4d5=063 is divisible by 3
            //d4d5d6=635 is divisible by 5
            //d5d6d7=357 is divisible by 7
            //d6d7d8=572 is divisible by 11
            //d7d8d9=728 is divisible by 13
            //d8d9d10=289 is divisible by 17

            long sum = 0;

            Parallel.For(0, 9999, d1d2d3d4 =>
            //for (int d1d2d3d4 = 0; d1d2d3d4 < 9999; d1d2d3d4++)
            {
                Console.Write('.');

                if (AllDigitsUnique(d1d2d3d4, 4)
                    && Divisible(d1d2d3d4, 2, 2, 4))
                {
                    for (int d5d6d7 = 0; d5d6d7 < 999; d5d6d7++)
                    {
                        if (!AllDigitsUnique(d1d2d3d4 * 1000 + d5d6d7, 7)
                            || !Divisible(d5d6d7, 1, 7, 3))
                        {
                            continue;
                        }

                        for (int d8d9d10 = 0; d8d9d10 < 999; d8d9d10++)
                        {
                            if (!AllDigitsUnique(d1d2d3d4 * 1000 * 1000L + d5d6d7 * 1000 + d8d9d10, 10))
                            {
                                continue;
                            }

                            long x = long.Parse(string.Join("", new[] { d1d2d3d4, d5d6d7, d8d9d10 }));

                            if (CheckMagic(x))
                            {
                                Console.Write(x);
                                sum += x;
                            }
                        }
                    }
                }
            });

            Console.WriteLine("---");
            Console.WriteLine(sum);
        }

        static bool AllDigitsUnique(long x, int w)
        {
            HashSet<char> chars = new HashSet<char>();

            string f = new string('0', w);

            foreach (var c in x.ToString(f))
            {
                chars.Add(c);
            }

            return chars.Count == x.ToString(f).Length;
        }

        static bool Pandigital(long x)
        {
            return new string (x.ToString().OrderBy(c => c).ToArray()) == "0123456789";
        }

        static bool CheckMagic(long x)
        {
            return Divisible(x, 2, 2)
                && Divisible(x, 3, 3)
                && Divisible(x, 4, 5)
                && Divisible(x, 5, 7)
                && Divisible(x, 6, 11)
                && Divisible(x, 7, 13)
                && Divisible(x, 8, 17);
        }

        static bool Divisible(long x, int starting, int divider, int w = 10)
        {
            long d = long.Parse(x.ToString(new string('0', w)).Substring(starting - 1, 3));

            return d % divider == 0;
        }
    }
}
