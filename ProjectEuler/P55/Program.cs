using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P55
{
    class Program
    {
        public const int MAX_ITERATIONS = 50;

        static void Main(string[] args)
        {
            int r = 0;

            Action sol = () =>
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        int iterationsToFormPolyndrom = IsLychrel(new BigInteger(i));

                        if (iterationsToFormPolyndrom == -1)
                        {
                            r += 1;
                        }

                        //string.Format("{0}: {1} {2} iterations to get polyndrom",
                        //    i,
                        //    iterationsToFormPolyndrom == -1 ? "Lychrel Num" : "NOT Lychrel Num",
                        //    iterationsToFormPolyndrom
                        //    ).Dump();
                    }
                };

            sol.RunAndTime();

            r.Dump("Answer");
        }

        public static int IsLychrel(BigInteger x, int restIterations = MAX_ITERATIONS, bool first = true)
        {
            if (restIterations > 0)
            {
                if (!first && IsPolyndrom(x))
                {
                    return MAX_ITERATIONS - restIterations + 1;
                } else
                {
                    var next =  Reverse(x) + x;

                    return IsLychrel(next, restIterations - 1, false);
                }
            }

            return -1;
        }

        public static BigInteger Reverse(BigInteger x)
        {
            var reversed = new string(x.ToString().Reverse().ToArray());

            return BigInteger.Parse(reversed);
        }

        public static bool IsPolyndrom(BigInteger x)
        {
            string s = x.ToString();

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
