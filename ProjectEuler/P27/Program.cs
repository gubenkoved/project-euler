using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using System.Diagnostics;

namespace P27
{
    class Program
    {
        static void Main(string[] args)
        {
            //n² + an + b, where |a| < 1000 and |b| < 1000

            Action solution = () =>
                {
                    //PrimesUtilities.PrecalculateEratosphenPrimesTo(10000);

                    const int limit = 1000;

                    int maxConsequentivePrimes = 0;
                    int aSolution = 0;
                    int bSolution = 0;

                    for (int a = -limit; a < limit; a++)
                    {
                        //a.Dump(); // progress indicator

                        for (int b = -limit; b < limit; b++)
                        {
                            int consequentivePrimes = 0;
                            int n = 0;

                            do
                            {
                                int v = n * n + a * n + b;

                                if (PrimesUtilities.IsPrime(v))
                                {
                                    consequentivePrimes += 1;
                                }
                                else
                                {
                                    break;
                                }

                                n += 1;
                            } while (true);

                            if (consequentivePrimes > maxConsequentivePrimes)
                            {
                                maxConsequentivePrimes = consequentivePrimes;
                                aSolution = a;
                                bSolution = b;
                            }
                        }
                    }

                    (aSolution * bSolution).Dump("Solution");
                    maxConsequentivePrimes.Dump("Consequentive primes generated");
                };

            solution.RunAndTime();
        }
    }
}
