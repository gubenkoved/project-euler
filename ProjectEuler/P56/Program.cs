using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P56
{
    class Program
    {
        static void Main(string[] args)
        {
            Action s = () =>
                {

                    int maxDSum = 0;

                    for (int a = 1; a <= 100; a++)
                    {
                        for (int b = 1; b <= 100; b++)
                        {
                            BigInteger x = BigInteger.Pow(a, b);

                            int dsum = DSum(x);
                            if (dsum > maxDSum)
                            {
                                maxDSum = dsum;
                                string.Format("{0}^{1}, DSum={2}", a, b, maxDSum).Dump();
                            }
                        }
                    }
                };

            s.RunAndTime();
        }

        public static int DSum(BigInteger x)
        {
            int r = 0;

            foreach(char c in x.ToString())
            {
                //r += int.Parse(c.ToString());
                r += (int)(c - '0');
            }

            return r;
        }
    }
}
