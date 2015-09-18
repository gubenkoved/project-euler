using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "987654321";

            do
            {
                foreach (var p in CombinatoricsUtilities.Permutations(s))
                {
                    long n = long.Parse(string.Join("", p));

                    if (PrimesUtilities.IsPrime(n))
                    {
                        n.Dump("LARGEST PANDIGITAL PRIME");

                        return;
                    }
                }

                s = s.Substring(1);
            } while (s.Length > 0);
        }
    }
}
