using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P57
{
    class Program
    {
        const int NumOfExpansions = 1000;

        static void Main(string[] args)
        {
            Action s = () =>
                {

                    int r = 0;

                    var dSerie = D().Take(NumOfExpansions).ToArray();

                    for (int i = 0; i < NumOfExpansions; i++)
                    {
                        var d = dSerie[i];
                        var n = d + (i > 0 ? dSerie[i - 1] : 1);

                        //string.Format("{0}/{1}", n, d).Dump();

                        if (n.ToString().Length > d.ToString().Length)
                        {
                            r += 1;
                        }

                    }

                    r.Dump("Answer");
                };

            s.RunAndTime();
        }

        /// <summary>
        /// Denominators series for (1 / 2 + (1 / 2 +...)) 
        /// </summary>
        static public IEnumerable<BigInteger> D()
        {
            BigInteger dpp = 1;
            BigInteger dp = 2;

            //yield return dpp;
            yield return dp;

            while(true)
            {
                BigInteger d = 2 * dp + dpp;

                dpp = dp;
                dp = d;

                yield return d;
            }
        }
    }
}
