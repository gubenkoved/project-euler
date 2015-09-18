using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P33
{
    class Program
    {
        static void Main(string[] args)
        {
            long max = 100;

            for (long n = 1; n < max; n++)
            {
                for (long d = n + 1; d < max; d++)
                {
                    var f = decimal.Divide(n, d);

                    foreach (var digit in n.ToString())
                    {
                        if (!d.ToString().Contains(digit))
                        {
                            continue;
                        }

                        if (digit == '0')
                        {
                            continue;
                        }

                        var nNew = CancelDigit(n, digit);
                        var dNew = CancelDigit(d, digit);

                        if (dNew == 0)
                        {
                            continue;
                        }

                        var fNew = decimal.Divide(nNew, dNew);

                        if (f == fNew)
                        {
                            string.Format("{0}/{1} = {2}/{3} ({4} out)", n, d, nNew, dNew, digit).Dump();
                        }
                    }
                }
            }
        }

        public static long CancelDigit(long x, char d)
        {
            string s = x.ToString().Replace(d.ToString(), "");

            if (s == "")
            {
                return 0;
            }

            return long.Parse(s);
        }
    }
}
