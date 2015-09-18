using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P32
{
    class Program
    {
        static void Main(string[] args)
        {
            var all = CombinatoricsUtilities.Permutations(Enumerable.Range(1, 9));

            var magicProducts = new HashSet<int>();

            foreach (var permutation in all.Select(p => string.Join("", p)))
            {
                // X1 X2 X3 ... X9
                // can multiply and equality signs be placed to form valid equation?
                // X1 x X2 X3 X3 X4 = X5 X6 X7 X8 X9
                // X1 X2 x X3 X3 X4 = X5 X6 X7 X8 X9
                // X1 X2 X3 x X3 X4 = X5 X6 X7 X8 X9
                // X1 X2 X3 X3 x X4 = X5 X6 X7 X8 X9

                for (int multLoc = 1; multLoc < 9 - 2; multLoc++)
                {
                    for (int equalsLoc = multLoc + 1; equalsLoc < 9; equalsLoc++)
                    {
                        // check that it forms correct equation
                        // a x b = c

                        int a = int.Parse(permutation.Substring(0, multLoc));
                        int b = int.Parse(permutation.Substring(multLoc, equalsLoc - multLoc));
                        int c = int.Parse(permutation.Substring(equalsLoc));

                        if (a * b == c)
                        {
                            string.Format("{0} x {1} = {2}", a, b, c).Dump();

                            magicProducts.Add(c);
                        }
                    }
                }
            }

            magicProducts.Sum().Dump("Answer");
        }
    }
}
